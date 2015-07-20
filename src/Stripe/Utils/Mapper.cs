#region

using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace Stripe.Utils
{
	public static class Mapper<T>
	{
		public static List<T> MapCollectionFromJson(string json, string token = "data")
		{
			var jObject = JObject.Parse(json);
			var allTokens = jObject.SelectToken(token);
			return allTokens.Select(t => MapFromJson(t.ToString())).ToList();
		}

		public static T MapFromJson(string json, string parentToken = null)
		{
			var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();

			return JsonConvert.DeserializeObject<T>(jsonToParse);
		}
	}
}