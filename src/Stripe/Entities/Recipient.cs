#region

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Recipient : BaseEntity
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("livemode")]
		public bool LiveMode { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("active_account")]
		public RecipientActiveAccount ActiveAccount { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("cards")]
		public StripeList<Card> StripeCardList { get; set; }

		[JsonProperty("verified")]
		public bool Verified { get; set; }

		#region Expandable Default Card

		public string DefaultCardId { get; set; }

		[JsonIgnore]
		public Card DefaultCard { get; set; }

		[JsonProperty("default_card")]
		internal object InternalDefaultCard
		{
			set { ExpandableProperty<Card>.Map(value, s => this.DefaultCardId = s, o => this.DefaultCard = o); }
		}

		#endregion
	}
}