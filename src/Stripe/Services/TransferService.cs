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
	public class TransferService : BaseService
	{
		public bool ExpandBalanceTransaction { get; set; }

		public virtual async Task<Transfer> Create(TransferCreateOptions options)
		{
			var url = this.ApplyAllParameters(options, Urls.Transfers, false);

			var response = await Requestor.Post(url);

			return Mapper<Transfer>.MapFromJson(response);
		}

		public virtual async Task<Transfer> Get(string transferId)
		{
			var url = string.Format("{0}/{1}", Urls.Transfers, transferId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Transfer>.MapFromJson(response);
		}

		public virtual async Task<Transfer> Cancel(string transferId)
		{
			var url = string.Format("{0}/{1}/cancel", Urls.Transfers, transferId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Transfer>.MapFromJson(response);
		}

		public virtual async Task<IEnumerable<Transfer>> List(TransferListOptions options = null)
		{
			var url = Urls.Transfers;
			url = this.ApplyAllParameters(options, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Transfer>.MapCollectionFromJson(response);
		}
	}
}