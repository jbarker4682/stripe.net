#region

using System;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Period
	{
		[JsonProperty("start"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? Start { get; set; }

		[JsonProperty("end"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? End { get; set; }
	}
}