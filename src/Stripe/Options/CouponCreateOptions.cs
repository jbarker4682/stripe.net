﻿#region

using System;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Options
{
	public class CouponCreateOptions
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("amount_off")]
		public int? AmountOff { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("percent_off")]
		public int? PercentOff { get; set; }

		[JsonProperty("duration")]
		public string Duration { get; set; }

		[JsonProperty("duration_in_months")]
		public int? DurationInMonths { get; set; }

		[JsonProperty("max_redemptions")]
		public int? MaxRedemptions { get; set; }

		public DateTime? RedeemBy { get; set; }

		[JsonProperty("redeem_by")]
		internal long? RedeemByInternal
		{
			get
			{
				if (!this.RedeemBy.HasValue)
				{
					return null;
				}

				return this.RedeemBy.Value.ConvertDateTimeToEpoch();
			}
		}
	}
}