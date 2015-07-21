﻿using Newtonsoft.Json;

namespace Stripe.Entities
{
	public class Birthday
	{
		[JsonProperty("day")]
		public int? Day { get; set; }

		[JsonProperty("month")]
		public int? Month { get; set; }

		[JsonProperty("year")]
		public int? Year { get; set; }

	}
}