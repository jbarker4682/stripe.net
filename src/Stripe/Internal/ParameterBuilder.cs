#region

using System.Linq;
using System.Reflection;
using System.Web;

using Newtonsoft.Json;

#endregion

namespace Stripe.Internal
{
	internal static class ParameterBuilder
	{
		internal static string ApplyParameterToUrl(string url, string argument, string value)
		{
			var token = "&";

			if (!url.Contains("?"))
			{
				token = "?";
			}

			return string.Format("{0}{1}{2}={3}", url, token, argument, HttpUtility.UrlEncode(value));
		}

		internal static string ApplyNestedObjectProperties(string newUrl, object nestedObject)
		{
			foreach (var prop in nestedObject.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
			{
				var val = prop.GetValue(nestedObject, null);
				if (val == null)
				{
					continue;
				}

				newUrl = prop
					.GetCustomAttributes(typeof(JsonPropertyAttribute), false)
					.Cast<JsonPropertyAttribute>()
					.Aggregate(newUrl, (current, attr) => ApplyParameterToUrl(current, attr.PropertyName, val.ToString()));
			}

			return newUrl;
		}
	}
}