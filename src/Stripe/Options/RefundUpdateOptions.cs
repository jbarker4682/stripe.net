#region

using System.Collections.Generic;

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class RefundUpdateOptions
	{
		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }
	}
}