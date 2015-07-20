#region

using System.Collections.Generic;

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class RecipientUpdateOptions
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("tax_id")]
		public string TaxId { get; set; }

		[JsonProperty("bank_account")]
		public BankAccountOptions BankAccount { get; set; }

		[JsonProperty("card")]
		public CreditCardOptions Card { get; set; }

		[JsonProperty("default_card")]
		public string DefaultCardId { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }
	}
}