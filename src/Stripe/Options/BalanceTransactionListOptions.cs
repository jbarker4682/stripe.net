#region

using Newtonsoft.Json;

using Stripe.Entities;

#endregion

namespace Stripe.Options
{
	public class BalanceTransactionListOptions : StripeListOptions
	{
		[JsonProperty("available_on")]
		public DateFilter AvailableOn { get; set; }

		[JsonProperty("created")]
		public DateFilter Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("source")]
		public string SourceId { get; set; }

		[JsonProperty("transfer")]
		public string TransferId { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}