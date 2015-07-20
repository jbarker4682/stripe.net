#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Options
{
	public class InvoiceUpdateOptions
	{
		[JsonProperty("application_fee")]
		public int? ApplicationFee { get; set; }

		[JsonProperty("closed")]
		public bool? Closed { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("forgiven")]
		public bool? Forgiven { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }

		[JsonProperty("tax_percent")]
		public decimal? TaxPercent { get; set; }

		[JsonProperty("plan")]
		public string PlanId { get; set; }

		[JsonProperty("coupon")]
		public string CouponId { get; set; }

		[JsonProperty("quantity")]
		public int? Quantity { get; set; }

		#region Expndable TrialEnd

		public DateTime? TrialEnd { get; set; }

		public bool EndTrialNow { get; set; }

		[JsonProperty("trial_end")]
		internal string TrialEndInternal
		{
			get
			{
				if (this.EndTrialNow)
				{
					return "now";
				}
				if (this.TrialEnd.HasValue)
				{
					return this.TrialEnd.Value.ConvertDateTimeToEpoch().ToString();
				}
				return null;
			}
		}

		#endregion
	}
}