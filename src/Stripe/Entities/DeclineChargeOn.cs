using Newtonsoft.Json;

namespace Stripe.Entities
{
	public class DeclineChargeOn
	{
		[JsonProperty("cvc_failure")]
		public bool CvcFailure { get; set; }

		[JsonProperty("avs_failure")]
		public bool AvsFailure { get; set; }
	}
}