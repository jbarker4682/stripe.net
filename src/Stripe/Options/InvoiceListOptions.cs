#region

using Newtonsoft.Json;

using Stripe.Entities;

#endregion

namespace Stripe.Options
{
	public class InvoiceListOptions : StripeListOptions
	{
		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		[JsonProperty("date")]
		public DateFilter Date { get; set; }
	}
}