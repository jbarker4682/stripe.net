#region

using System;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class ApplicationFee : BaseEntity
	{
		[JsonProperty("livemode")]
		public bool? LiveMode { get; set; }

		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("application")]
		public string ApplicationId { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("refunded")]
		public bool Refunded { get; set; }

		[JsonProperty("refunds")]
		public StripeList<ApplicationFee> ApplicationFeeRefundList { get; set; }

		[JsonProperty("amount_refunded")]
		public int AmountRefunded { get; set; }

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

		#region Expandable Card

		public string CardId { get; set; }

		[JsonIgnore]
		public Card Card { get; set; }

		[JsonProperty("card")]
		internal object InternalCard
		{
			set { ExpandableProperty<Card>.Map(value, s => this.CardId = s, o => this.Card = o); }
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

		#region Expandable Account

		public string AccountId { get; set; }

		[JsonIgnore]
		public Account Account { get; set; }

		[JsonProperty("account")]
		internal object InternalAccount
		{
			set { ExpandableProperty<Account>.Map(value, s => this.AccountId = s, o => this.Account = o); }
		}

		#endregion
	}
}