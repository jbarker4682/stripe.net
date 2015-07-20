#region

using System.Collections.Generic;

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class InvoiceItemUpdateOptions
	{
		[JsonProperty("amount")]
		public int? Amount { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("discountable")]
		public bool Discountable { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }
	}
}