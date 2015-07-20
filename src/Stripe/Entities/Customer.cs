#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Customer : BaseEntity
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("livemode")]
		public bool LiveMode { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("account_balance")]
		public int AccountBalance { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("delinquent")]
		public bool Delinquent { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("discount")]
		public Discount Discount { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("sources")]
		public StripeList<Card> SourceList { get; set; }

		[JsonProperty("subscriptions")]
		public StripeList<Subscription> StripeSubscriptionList { get; set; }

		[JsonProperty("deleted")]
		public bool? Deleted { get; set; }

		#region Expandable Default Source

		public string DefaultSourceId { get; set; }

		[JsonIgnore]
		public Card DefaultSource { get; set; }

		[JsonProperty("default_source")]
		internal object InternalDefaultSource
		{
			set { ExpandableProperty<Card>.Map(value, s => this.DefaultSourceId = s, o => this.DefaultSource = o); }
		}

		#endregion
	}
}