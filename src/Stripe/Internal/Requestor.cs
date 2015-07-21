#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Exceptions;
using Stripe.Utils;

#endregion

namespace Stripe.Internal
{
	internal static class Requestor
	{
		private const string GET = "GET";
		private const string POST = "POST";
		private const string DELETE = "DELETE";

		public static Task<string> Get(string url)
		{
			var request = CreateWebRequest(url);
			return ExecuteWebRequestAsync(request);
		}

		public static Task<string> Post(string url, bool useBearerToken = false, string data = null)
		{
			var request = CreateWebRequest(url, POST, useBearerToken, data);
			return ExecuteWebRequestAsync(request);
		}

		public static Task<string> Delete(string url)
		{
			var request = CreateWebRequest(url, DELETE);
			return ExecuteWebRequestAsync(request);
		}

		internal static WebRequest CreateWebRequest(string url, string method = GET, bool useBearerToken = false, string data = null)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);

			request.Method = method;
			request.Headers.Add("Authorization", GetAuthorizationHeader(useBearerToken));
			request.Headers.Add("Stripe-Version", StripeConfiguration.ApiVersion);
			request.ContentType = "application/x-www-form-urlencoded";
			request.UserAgent = "Stripe.Net";

			if (request.Method == POST && !string.IsNullOrEmpty(data))
			{
				var byteArray = Encoding.UTF8.GetBytes(data);
				request.ContentLength = byteArray.Length;

				using (var stream = request.GetRequestStream())
				{
					stream.Write(byteArray, 0, byteArray.Length);
					stream.Close();
				}
			}

			return request;
		}

		private static string GetAuthorizationHeader(bool useBearerToken)
		{
			var apiKey = StripeConfiguration.ApiKey;

			if (useBearerToken)
			{
				return string.Format("Bearer {0}", apiKey);
			}

			var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", apiKey)));
			return string.Format("Basic {0}", token);
		}

		private static async Task<string> ExecuteWebRequestAsync(WebRequest request)
		{
			ExceptionDispatchInfo capturedException;

			try
			{
				using (var response = await request.GetResponseAsync())
				{
					return await ReadStreamAsync(response.GetResponseStream());
				}
			}
			catch (WebException ex)
			{
				if (ex.Response == null)
				{
					throw;
				}
				capturedException = ExceptionDispatchInfo.Capture(ex);
			}

			var wex = (WebException)capturedException.SourceException;
			var statusCode = ((HttpWebResponse)wex.Response).StatusCode;

			using (var stream = wex.Response.GetResponseStream())
			{
				var result = await ReadStreamAsync(stream);
				var stripeError = request.RequestUri.ToString().Contains("oauth")
					                  ? Mapper<StripeError>.MapFromJson(result)
					                  : Mapper<StripeError>.MapFromJson(result, "error");

				throw new StripeException(statusCode, stripeError, stripeError.Message);
			}
		}

		private static Task<string> ReadStreamAsync(Stream stream)
		{
			using (var reader = new StreamReader(stream, Encoding.UTF8))
			{
				return reader.ReadToEndAsync();
			}
		}

		public static Task<string> PostMultipartFormString(string url, Dictionary<string, string> data, Stream file, string name, string mimeType, string formKey)
		{
			var request = (HttpWebRequest)CreateWebRequest(url, POST);

			request.ContentType = "application/x-www-form-urlencoded";
			request.KeepAlive = true;

			//Creates a multipart/form-data boundary.
			var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
			request.ContentType = "multipart/form-data; boundary=" + boundary;

			using (var requestStream = request.GetRequestStream())
			{
				data.WriteMultipartFormData(requestStream, boundary);
				if (file != null)
				{
					file.WriteMultipartFormData(name, requestStream, boundary, mimeType, formKey);
				}

				var endBytes = Encoding.UTF8.GetBytes("--" + boundary + "--");
				requestStream.Write(endBytes, 0, endBytes.Length);
				requestStream.Close();
			}

			return ExecuteWebRequestAsync(request);
		}
	}
}