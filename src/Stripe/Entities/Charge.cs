#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Charge : BaseEntity
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("livemode")]
		public bool LiveMode { get; set; }

		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("captured")]
		public bool? Captured { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("paid")]
		public bool Paid { get; set; }

		[JsonProperty("refunded")]
		public bool Refunded { get; set; }

		[JsonProperty("refunds")]
		public StripeList<Refund> StripeRefundList { get; set; }

		[JsonProperty("source")]
		public Card Source { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("amount_refunded")]
		public int AmountRefunded { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("dispute")]
		public Dispute Dispute { get; set; }

		[JsonProperty("failure_code")]
		public string FailureCode { get; set; }

		[JsonProperty("failure_message")]
		public string FailureMessage { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("receipt_email")]
		public string ReceiptEmail { get; set; }

		[JsonProperty("receipt_number")]
		public string ReceiptNumber { get; set; }

		#region Expandable Invoice

		public string InvoiceId { get; set; }

		[JsonIgnore]
		public Invoice Invoice { get; set; }

		[JsonProperty("invoice")]
		internal object InternalInvoice
		{
			set { ExpandableProperty<Invoice>.Map(value, s => this.InvoiceId = s, o => this.Invoice = o); }
		}

		#endregion

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

		// application_fee

		// destination

		// todo: hash, fraud details

		// todo: hash, shipping

		// transfer
	}
}