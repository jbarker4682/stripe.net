#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Transfer : BaseEntity
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("livemode")]
		public bool LiveMode { get; set; }

		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("date"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Date { get; set; }

		[JsonProperty("reversals")]
		public StripeList<TransferReversal> StripeTransferReversalList { get; set; }

		[JsonProperty("reversed")]
		public bool Reversed { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("amount_reversed")]
		public int AmountReversed { get; set; }

		public string BalanceTransactionId { get; set; }

		public BalanceTransaction BalanceTransaction { get; set; }

		[JsonProperty("balance_transaction")]
		internal object InternalBalanceTransaction
		{
			set { ExpandableProperty<BalanceTransaction>.Map(value, s => this.BalanceTransactionId = s, o => this.BalanceTransaction = o); }
		}

		[JsonProperty("destination")]
		public string Destination { get; set; }

		[JsonProperty("destination_payment")]
		public string DestinationPayment { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("failure_code")]
		public string FailureCode { get; set; }

		[JsonProperty("failure_message")]
		public string FailureMessage { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("bank_account")]
		public BankAccount BankAccount { get; set; }

		[JsonProperty("card")]
		public Card Card { get; set; }

		public string RecipientId { get; set; }

		[JsonIgnore]
		public Recipient Recipient { get; set; }

		[JsonProperty("recipient")]
		internal object InternalRecipient
		{
			set { ExpandableProperty<Recipient>.Map(value, s => this.RecipientId = s, o => this.Recipient = o); }
		}

		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }

		[JsonProperty("source_transaction")]
		public string SourceTransaction { get; set; }
	}
}