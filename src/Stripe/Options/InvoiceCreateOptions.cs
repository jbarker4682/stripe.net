﻿#region

using System.Collections.Generic;

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class InvoiceCreateOptions
	{
		[JsonProperty("application_fee")]
		public int? ApplicationFee { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }

		[JsonProperty("subscription")]
		public string SubscriptionId { get; set; }

		[JsonProperty("tax_percent")]
		public decimal? TaxPercent { get; set; }
	}
}