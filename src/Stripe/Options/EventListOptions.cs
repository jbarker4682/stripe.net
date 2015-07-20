#region

using Newtonsoft.Json;

using Stripe.Entities;

#endregion

namespace Stripe.Options
{
	public class EventListOptions : StripeListOptions
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("created")]
		public DateFilter Created { get; set; }
	}
}