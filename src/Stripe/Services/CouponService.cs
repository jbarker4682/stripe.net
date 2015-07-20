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
	public class CouponService : BaseService
	{
		public virtual async Task<Coupon> Create(CouponCreateOptions createOptions)
		{
			var url = this.ApplyAllParameters(createOptions, Urls.Coupons, false);

			var response = await Requestor.Post(url);

			return Mapper<Coupon>.MapFromJson(response);
		}

		public virtual async Task<Coupon> Get(string couponId)
		{
			var url = string.Format("{0}/{1}", Urls.Coupons, couponId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Coupon>.MapFromJson(response);
		}

		public virtual async void Delete(string couponId)
		{
			var url = string.Format("{0}/{1}", Urls.Coupons, couponId);
			url = this.ApplyAllParameters(null, url, false);

			await Requestor.Delete(url);
		}

		public virtual async Task<IEnumerable<Coupon>> List(StripeListOptions listOptions = null)
		{
			var url = Urls.Coupons;
			url = this.ApplyAllParameters(listOptions, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Coupon>.MapCollectionFromJson(response);
		}
	}
}