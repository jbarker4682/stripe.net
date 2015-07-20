using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Options;
using Stripe.Utils;

namespace Stripe.Services
{
	public class ApplicationFeeService : BaseService
	{
		public bool ExpandAccount { get; set; }
		public bool ExpandBalanceTransaction { get; set; }
		public bool ExpandCharge { get; set; }

		public virtual async Task<ApplicationFee> Get(string applicationFeeId)
		{
			var url = string.Format("{0}/{1}", Urls.ApplicationFees, applicationFeeId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<ApplicationFee>.MapFromJson(response);
		}

		public virtual async Task<ApplicationFee> Refund(string applicationFeeId, int? refundAmount = null)
		{
			var url = string.Format("{0}/{1}/refund", Urls.ApplicationFees, applicationFeeId);
			url = this.ApplyAllParameters(null, url, false);

			if (refundAmount.HasValue)
			{
				url = ParameterBuilder.ApplyParameterToUrl(url, "amount", refundAmount.Value.ToString(CultureInfo.InvariantCulture));
			}

			var response = await Requestor.Post(url);

			return Mapper<ApplicationFee>.MapFromJson(response);
		}

		public virtual async Task<IEnumerable<ApplicationFee>> List(ApplicationFeeListOptions options)
		{
			var url = Urls.ApplicationFees;
			url = this.ApplyAllParameters(options, url, true);

			var response = await Requestor.Get(url);

			return Mapper<ApplicationFee>.MapCollectionFromJson(response);
		}
	}
}