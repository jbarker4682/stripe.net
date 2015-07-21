﻿using Newtonsoft.Json;

namespace Stripe.Entities
{
	public class TermsAcceptance
	{
		[JsonProperty("date")]
		public long? Date { get; set; }

		[JsonProperty("ip")]
		public string Ip { get; set; }

		[JsonProperty("user_agent")]
		public string UserAgent { get; set; }
	}
}