using Newtonsoft.Json;

namespace Stripe.Entities
{
	public class LegalEntityVerification
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("document")]
		public string Document { get; set; }

		[JsonProperty("details")]
		public string Details { get; set; }
	}
}