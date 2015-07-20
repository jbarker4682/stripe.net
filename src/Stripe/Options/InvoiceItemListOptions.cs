#region

using Newtonsoft.Json;

using Stripe.Entities;

#endregion

namespace Stripe.Options
{
	public class InvoiceItemListOptions : StripeListOptions
	{
		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		[JsonProperty("created")]
		public DateFilter Created { get; set; }
	}
}