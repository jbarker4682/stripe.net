﻿#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Annotations;
using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Coupon : BaseEntity
	{
		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("duration")]
		public string Duration { get; set; }

		[JsonProperty("duration_in_months")]
		public int? DurationInMonths { get; set; }

		[JsonProperty("livemode")]
		public bool? LiveMode { get; set; }

		[JsonProperty("max_redemptions")]
		public int? MaxRedemptions { get; set; }

		[JsonProperty("amount_off")]
		public int? AmountOff { get; set; }

		[JsonProperty("percent_off")]
		public int? PercentOff { get; set; }

		[JsonProperty("redeem_by"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? RedeemBy { get; set; }

		[JsonProperty("times_redeemed")]
		public int TimesRedeemed { get; [UsedImplicitly] private set; }

		[JsonProperty("valid")]
		public bool Valid { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }
	}
}