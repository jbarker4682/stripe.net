using System;

using Newtonsoft.Json;

using Stripe.Internal;

namespace Stripe.Entities
{
	public class AccountVerification
	{
		[JsonProperty("contacted")]
		public bool Contacted { get; set; }

		[JsonProperty("fields_needed")]
		public string[] FieldsNeeded { get; set; }

		[JsonProperty("due_by"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? DueBy { get; set; }
	}
}