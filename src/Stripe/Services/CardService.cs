#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Options;
using Stripe.Utils;

#endregion

namespace Stripe.Services
{
	public class CardService : BaseService
	{
		public bool ExpandCustomer { get; set; }
		public bool ExpandRecipient { get; set; }

		public virtual async Task<Card> Create(string customerOrRecipientId, CardCreateOptions options, bool isRecipient = false)
		{
			var url = this.SetupUrl(customerOrRecipientId, isRecipient);
			url = this.ApplyAllParameters(options, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Card>.MapFromJson(response);
		}

		public virtual async Task<Card> Get(string customerOrRecipientId, string cardId, bool isRecipient = false)
		{
			var url = this.SetupUrl(customerOrRecipientId, isRecipient, cardId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Card>.MapFromJson(response);
		}

		public virtual async Task<Card> Update(string customerOrRecipientId, string cardId, CardUpdateOptions options, bool isRecipient = false)
		{
			var url = this.SetupUrl(customerOrRecipientId, isRecipient, cardId);
			url = this.ApplyAllParameters(options, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Card>.MapFromJson(response);
		}

		public virtual void Delete(string customerOrRecipientId, string cardId, bool isRecipient = false)
		{
			var url = this.SetupUrl(customerOrRecipientId, isRecipient, cardId);

			Requestor.Delete(url);
		}

		public virtual async Task<IEnumerable<Card>> List(string customerOrRecipientId, StripeListOptions options = null, bool isRecipient = false)
		{
			var url = this.SetupUrl(customerOrRecipientId, isRecipient);
			url = this.ApplyAllParameters(options, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Card>.MapCollectionFromJson(response);
		}

		private string SetupUrl(string customerOrRecipientId, bool isRecipient, string cardId = null)
		{
			var urlParams = string.Format(Urls.CustomerCards, customerOrRecipientId);

			if (isRecipient)
			{
				urlParams = string.Format(Urls.RecipientCards, customerOrRecipientId);
			}

			return String.IsNullOrEmpty(cardId) ? urlParams : string.Format("{0}/{1}", urlParams, cardId);
		}
	}
}