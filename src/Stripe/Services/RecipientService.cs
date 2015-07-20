#region

using System.Collections.Generic;
using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Options;
using Stripe.Utils;

#endregion

namespace Stripe.Services
{
	public class RecipientService : BaseService
	{
		public bool ExpandDefaultCard { get; set; }

		public virtual async Task<Recipient> Create(RecipientCreateOptions options)
		{
			var url = this.ApplyAllParameters(options, Urls.Recipients, false);

			var response = await Requestor.Post(url);

			return Mapper<Recipient>.MapFromJson(response);
		}

		public virtual async Task<Recipient> Get(string recipientId)
		{
			var url = string.Format("{0}/{1}", Urls.Recipients, recipientId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Recipient>.MapFromJson(response);
		}

		public virtual async Task<Recipient> Update(string recipientId, RecipientUpdateOptions options)
		{
			var url = string.Format("{0}/{1}", Urls.Recipients, recipientId);
			url = this.ApplyAllParameters(options, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Recipient>.MapFromJson(response);
		}

		public virtual async void Delete(string recipientId)
		{
			var url = string.Format("{0}/{1}", Urls.Recipients, recipientId);

			await Requestor.Delete(url);
		}

		public virtual async Task<IEnumerable<Recipient>> List(RecipientListOptions options = null)
		{
			var url = Urls.Recipients;
			url = this.ApplyAllParameters(options, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Recipient>.MapCollectionFromJson(response);
		}
	}
}