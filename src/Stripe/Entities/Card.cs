#region

using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Card : BaseEntity
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("brand")]
		public string Brand { get; set; }

		[JsonProperty("exp_month")]
		public string ExpirationMonth { get; set; }

		[JsonProperty("exp_year")]
		public string ExpirationYear { get; set; }

		[JsonProperty("funding")]
		public string Funding { get; set; }

		[JsonProperty("last4")]
		public string Last4 { get; set; }

		[JsonProperty("address_city")]
		public string AddressCity { get; set; }

		[JsonProperty("address_country")]
		public string AddressCountry { get; set; }

		[JsonProperty("address_line1")]
		public string AddressLine1 { get; set; }

		[JsonProperty("address_line1_check")]
		public string AddressLine1Check { get; set; }

		[JsonProperty("address_line2")]
		public string AddressLine2 { get; set; }

		[JsonProperty("address_state")]
		public string AddressState { get; set; }

		[JsonProperty("address_zip")]
		public string AddressZip { get; set; }

		[JsonProperty("address_zip_check")]
		public string AddressZipCheck { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("cvc_check")]
		public string CvcCheck { get; set; }

		[JsonProperty("dynamic_last4")]
		public string DynamicLast4 { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("tokenization_method")]
		public string TokenizationMethod { get; set; }

		[JsonProperty("fingerprint")]
		public string Fingerprint { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("default_for_currency")]
		public bool DefaultForCurrency { get; set; }

		#region Expandable Recipient

		public string RecipientId { get; set; }

		[JsonIgnore]
		public Recipient Recipient { get; set; }

		[JsonProperty("recipient")]
		internal object InternalRecipient
		{
			set { ExpandableProperty<Recipient>.Map(value, s => this.RecipientId = s, o => this.Recipient = o); }
		}

		#endregion

		#region Expandable Customer

		public string CustomerId { get; set; }

		[JsonIgnore]
		public Customer Customer { get; set; }

		[JsonProperty("customer")]
		internal object InternalCustomer
		{
			set { ExpandableProperty<Customer>.Map(value, s => this.CustomerId = s, o => this.Customer = o); }
		}

		#endregion

		#region Expandable Account

		public string AccountId { get; set; }

		[JsonIgnore]
		public Account Account { get; set; }

		[JsonProperty("account")]
		internal object InternalAccount
		{
			set { ExpandableProperty<Account>.Map(value, s => this.AccountId = s, o => this.Account = o); }
		}

		#endregion
	}
}