using System.Collections.Generic;

using Newtonsoft.Json;

namespace Stripe.Entities
{
	public class SubscriptionList //TODO: extend StripList<Subscription>
	{
		[JsonProperty("data")]
		public List<Subscription> Subscriptions { get; set; }

		[JsonProperty("has_more")]
		public bool HasMore { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("total_count")]
		public int? TotalCount { get; set; }
	}
}