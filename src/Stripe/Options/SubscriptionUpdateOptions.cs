#region

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class SubscriptionUpdateOptions : SubscriptionCreateOptions
	{
		[JsonProperty("prorate")]
		public bool? Prorate { get; set; }
	}
}