using Newtonsoft.Json;

namespace Stripe.Entities
{
	public class ManagedAccountKeys
	{
		[JsonProperty("secret")]
		public string Secret { get; set; }

		[JsonProperty("publishable")]
		public string Publishable { get; set; }
	}
}