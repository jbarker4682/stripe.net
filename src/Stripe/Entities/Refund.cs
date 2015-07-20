#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Refund : BaseEntity
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("reason")]
		public string Reason { get; set; }

		[JsonProperty("receipt_number")]
		public string ReceiptNumber { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		#region Expandable Balance Transaction

		public string BalanceTransactionId { get; set; }

		[JsonIgnore]
		public BalanceTransaction BalanceTransaction { get; set; }

		[JsonProperty("balance_transaction")]
		internal object InternalBalanceTransaction
		{
			set { ExpandableProperty<BalanceTransaction>.Map(value, s => this.BalanceTransactionId = s, o => this.BalanceTransaction = o); }
		}

		#endregion

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