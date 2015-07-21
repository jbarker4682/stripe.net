using System;

using Newtonsoft.Json;

using Stripe.Internal;

namespace Stripe.Entities
{
	public class DisputeEvidenceDetails
	{
		[JsonProperty("due_by"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? DueBy { get; set; }

		[JsonProperty("past_due")]
		public bool PastDue { get; set; }

		[JsonProperty("has_evidence")]
		public bool HasEvidence { get; set; }

		[JsonProperty("submission_count")]
		public int SubmissionCount { get; set; }
	}
}