using Newtonsoft.Json;

namespace Stripe.Entities
{
	public class AdditionalOwner
	{
		[JsonProperty("dob[day]")]
		public int? LegalEntityDobDay { get; set; }

		[JsonProperty("dob[month]")]
		public int? LegalEntityDobMonth { get; set; }

		[JsonProperty("dob[year]")]
		public int? LegalEntityDobYear { get; set; }

		[JsonProperty("first_name")]
		public string LegalEntityFirstName { get; set; }

		[JsonProperty("last_name")]
		public string LegalEntityLastName { get; set; }

		[JsonProperty("personal_address[line1]")]
		public string PersonalAddressLine1 { get; set; }

		[JsonProperty("personal_address[line2]")]
		public string PersonalAddressLine2 { get; set; }

		[JsonProperty("personal_address[city]")]
		public string PersonalAddressCity { get; set; }

		[JsonProperty("personal_address[state]")]
		public string PersonalAddressState { get; set; }

		[JsonProperty("personal_address[postal_code]")]
		public string PersonalAddressPostalCode { get; set; }

		[JsonProperty("personal_address[country]")]
		public string PersonalAddressCountry { get; set; }
	}
}