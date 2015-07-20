#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Options
{
	public class SubscriptionCreateOptions
	{
		[JsonProperty("plan")]
		public string PlanId { get; set; }

		[JsonProperty("coupon")]
		public string CouponId { get; set; }

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

		[JsonProperty("card")]
		public CreditCardOptions Card { get; set; }

		[JsonProperty("quantity")]
		public int? Quantity { get; set; }

		[JsonProperty("application_fee_percent")]
		public decimal? ApplicationFeePercent { get; set; }

		[JsonProperty("tax_percent")]
		public decimal? TaxPercent { get; set; }

		public DateTime? BillingCycleAnchor { get; set; }
		public bool BillingCycleAnchorNow { get; set; }
		public bool BillingCycleAnchorUnchanged { get; set; }

		[JsonProperty("billing_cycle_anchor")]
		internal string BillingCycleAnchorInternal
		{
			get
			{
				if (this.BillingCycleAnchorNow)
				{
					return "now";
				}
				if (this.BillingCycleAnchorUnchanged)
				{
					return "unchanged";
				}
				if (this.BillingCycleAnchor.HasValue)
				{
					return this.BillingCycleAnchor.Value.ConvertDateTimeToEpoch().ToString();
				}
				return null;
			}
		}

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }
	}
}