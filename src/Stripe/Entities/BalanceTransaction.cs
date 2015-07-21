#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class BalanceTransaction : BaseEntity
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("available_on"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime AvailableOn { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("fee")]
		public int Fee { get; set; }

		[JsonProperty("fee_details")]
		public List<Fee> FeeDetails { get; set; }

		[JsonProperty("net")]
		public int Net { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }

		[JsonProperty("sourced_transfers")]
		public StripeList<Transfer> SourcedTransfers { get; set; }
	}
}