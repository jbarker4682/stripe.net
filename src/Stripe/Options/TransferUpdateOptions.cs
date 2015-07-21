using Newtonsoft.Json;

namespace Stripe.Options
{
	public class TransferUpdateOptions
	{
		[JsonProperty("description")]
		public string Description { get; set; }
	}
}