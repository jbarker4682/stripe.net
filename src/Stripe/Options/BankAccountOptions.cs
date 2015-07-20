#region

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class BankAccountOptions
	{
		[JsonProperty("bank_account")]
		public string TokenId { get; set; }

		[JsonProperty("bank_account[country]")]
		public string Country { get; set; }

		[JsonProperty("bank_account[routing_number]")]
		public string RoutingNumber { get; set; }

		[JsonProperty("bank_account[account_number]")]
		public string AccountNumber { get; set; }
	}
}