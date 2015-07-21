using System;

using Newtonsoft.Json;

using Stripe.Internal;

namespace Stripe.Entities
{
	public class StripeDocument : BaseEntity
	{
		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("size")]
		public string Size { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}