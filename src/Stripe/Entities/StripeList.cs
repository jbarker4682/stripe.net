#region

using System.Collections.Generic;

using Newtonsoft.Json;

#endregion

namespace Stripe.Entities
{
	public class StripeList<T>
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("data")]
		public List<T> Data { get; set; }

		[JsonProperty("has_more")]
		public bool HasMore { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("total_count")]
		public int TotalCount { get; set; }
	}
}