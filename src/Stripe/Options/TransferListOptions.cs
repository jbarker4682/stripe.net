#region

using Newtonsoft.Json;

using Stripe.Entities;

#endregion

namespace Stripe.Options
{
	public class TransferListOptions : StripeListOptions
	{
		[JsonProperty("date")]
		public DateFilter Date { get; set; }

		[JsonProperty("created")]
		public DateFilter Created { get; set; }

		[JsonProperty("recipient")]
		public string RecipientId { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }
	}
}