#region

using Newtonsoft.Json;

using Stripe.Entities;

#endregion

namespace Stripe.Options
{
	public class CustomerListOptions : StripeListOptions
	{
		[JsonProperty("created")]
		public DateFilter Created { get; set; }
	}
}