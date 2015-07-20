#region

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class TokenCreateOptions
	{
		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		[JsonProperty("card")]
		public CreditCardOptions Card { get; set; }
	}
}