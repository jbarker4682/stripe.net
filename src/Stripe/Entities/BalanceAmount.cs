#region

using Newtonsoft.Json;

#endregion

namespace Stripe.Entities
{
	public class BalanceAmount
	{
		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}
}