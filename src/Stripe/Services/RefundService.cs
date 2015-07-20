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
	public class RefundService : BaseService
	{
		public bool ExpandBalanceTransaction { get; set; }

		public virtual async Task<Refund> Create(string chargeId, RefundCreateOptions options = null)
		{
			var url = string.Format("{0}/{1}/refunds", Urls.Charges, chargeId);
			url = this.ApplyAllParameters(options, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Refund>.MapFromJson(response);
		}

		public virtual async Task<Refund> Get(string chargeId, string refundId)
		{
			var url = string.Format("{0}/{1}/refunds/{2}", Urls.Charges, chargeId, refundId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Refund>.MapFromJson(response);
		}

		public virtual async Task<Refund> Update(string chargeId, string refundId, RefundUpdateOptions options)
		{
			var url = string.Format("{0}/{1}/refunds/{2}", Urls.Charges, chargeId, refundId);
			url = this.ApplyAllParameters(options, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Refund>.MapFromJson(response);
		}

		public virtual async Task<IEnumerable<Refund>> List(string chargeId, StripeListOptions options = null)
		{
			var url = string.Format("{0}/{1}/refunds", Urls.Charges, chargeId);
			url = this.ApplyAllParameters(options, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Refund>.MapCollectionFromJson(response);
		}
	}
}