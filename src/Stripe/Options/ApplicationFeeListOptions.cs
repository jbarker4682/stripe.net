#region

using Newtonsoft.Json;

using Stripe.Entities;

#endregion

namespace Stripe.Options
{
	public class ApplicationFeeListOptions : StripeListOptions
	{
		[JsonProperty("charge")]
		public string ChargeId { get; set; }

		[JsonProperty("created")]
		public DateFilter Created { get; set; }
	}
}