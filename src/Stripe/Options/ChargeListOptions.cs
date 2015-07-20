#region

using Newtonsoft.Json;

using Stripe.Entities;

#endregion

namespace Stripe.Options
{
	public class ChargeListOptions : StripeListOptions
	{
		[JsonProperty("created")]
		public DateFilter Created { get; set; }

		[JsonProperty("customer")]
		public string CustomerId { get; set; }
	}
}