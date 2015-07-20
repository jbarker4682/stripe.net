#region

using System;
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
		public static Task<string> Get(string url)
		{
			var wr = CreateWebRequest(url);
			return ExecuteWebRequestAsync(wr);
		}

		public static Task<string> Post(string url, bool useBearerToken = false)
		{
			var wr = CreateWebRequest(url, "POST", useBearerToken);
			return ExecuteWebRequestAsync(wr);
		}

		public static Task<string> Delete(string url)
		{
			var wr = CreateWebRequest(url, "DELETE");
			return ExecuteWebRequestAsync(wr);
		}

		internal static WebRequest CreateWebRequest(string url, string method = "GET", bool useBearerToken = false)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);

			request.Method = method;
			request.Headers.Add("Authorization", GetAuthorizationHeader(useBearerToken));
			request.Headers.Add("Stripe-Version", StripeConfiguration.ApiVersion);
			request.ContentType = "application/x-www-form-urlencoded";
			request.UserAgent = "Stripe.Net";

			return request;
		}

		private static string GetAuthorizationHeader(bool useBearerToken)
		{
			var apiKey = StripeConfiguration.ApiKey;

			if (!useBearerToken)
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
	}
}