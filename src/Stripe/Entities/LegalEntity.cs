using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Options;

namespace Stripe.Entities
{
	public class LegalEntity
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("business_name")]
		public string BusinessName { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("address")]
		public Address Address { get; set; }

		[JsonProperty("personal_address")]
		public Address PersonalAddress { get; set; }

		[JsonProperty("business_tax_id")]
		public string BusinessTaxId { get; set; }

		[JsonProperty("business_vat_id")]
		public string BusinessVatId { get; set; }

		[JsonProperty("dob")]
		public Birthday Birthday { get; set; }

		[JsonProperty("ssn_last_4")]
		public string LastFourSSN { get; set; }

		[JsonProperty("verification")]
		public LegalEntityVerification Verification { get; set; }

		[JsonProperty("additional_owners")]
		public IList<AdditionalOwner> AdditionalOwners { get; set; }
	}
}