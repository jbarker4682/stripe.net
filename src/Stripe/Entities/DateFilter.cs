﻿#region

using System;

using Newtonsoft.Json;

#endregion

namespace Stripe.Entities
{
	public class DateFilter
	{
		[JsonProperty("")]
		public DateTime? EqualTo { get; set; }

		[JsonProperty("[gt]")]
		public DateTime? GreaterThan { get; set; }

		[JsonProperty("[gte]")]
		public DateTime? GreaterThanOrEqual { get; set; }

		[JsonProperty("[lt]")]
		public DateTime? LessThan { get; set; }

		[JsonProperty("[lte]")]
		public DateTime? LessThanOrEqual { get; set; }
	}
}