#region

using System.Collections.Generic;

using Newtonsoft.Json;

#endregion

namespace Stripe.Entities
{
	public class Balance
	{
		[JsonProperty("livemode")]
		public bool LiveMode { get; set; }

		[JsonProperty("available")]
		public List<BalanceAmount> Available { get; set; }

		[JsonProperty("pending")]
		public List<BalanceAmount> Pending { get; set; }
	}
}