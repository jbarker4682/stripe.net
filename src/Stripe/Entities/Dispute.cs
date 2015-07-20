#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Dispute
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("livemode")]
		public bool LiveMode { get; set; }

		[JsonProperty("amount")]
		public int? Amount { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("reason")]
		public string Reason { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("balance_transactions")]
		public List<BalanceTransaction> BalanceTransactions { get; set; }

		// needs evidence object
		// needs evidence_details

		[JsonProperty("is_charge_refundable")]
		public bool IsChargeRefundable { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		#region Expandable Charge

		public string ChargeId { get; set; }

		[JsonIgnore]
		public Charge Charge { get; set; }

		[JsonProperty("charge")]
		internal object InternalCharge
		{
			set { ExpandableProperty<Charge>.Map(value, s => this.ChargeId = s, o => this.Charge = o); }
		}

		#endregion
	}
}