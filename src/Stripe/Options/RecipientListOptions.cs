#region

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class RecipientListOptions : StripeListOptions
	{
		[JsonProperty("verified")]
		public bool? Verified { get; set; }
	}
}