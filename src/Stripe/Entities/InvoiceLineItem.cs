#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class InvoiceLineItem : BaseEntity
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("livemode")]
		public bool LiveMode { get; set; }

		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("date"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Date { get; set; }

		[JsonProperty("proration")]
		public bool Proration { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("plan")]
		public Plan Plan { get; set; }

		[JsonProperty("quantity")]
		public int? Quantity { get; set; }

		[JsonProperty("subscription")]
		public string SubscriptionId { get; set; }

		[JsonProperty("period")]
		public Period Period { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

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
	}
}