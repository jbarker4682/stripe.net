#region

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Options;
using Stripe.Utils;

#endregion

namespace Stripe.Services
{
	public class ChargeService : BaseService
	{
		public bool ExpandBalanceTransaction { get; set; }
		public bool ExpandCustomer { get; set; }
		public bool ExpandInvoice { get; set; }

		public virtual async Task<Charge> Create(ChargeCreateOptions options)
		{
			var url = this.ApplyAllParameters(options, Urls.Charges, false);

			var response = await Requestor.Post(url);

			return Mapper<Charge>.MapFromJson(response);
		}

		public virtual async Task<Charge> Get(string chargeId)
		{
			var url = string.Format("{0}/{1}", Urls.Charges, chargeId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Charge>.MapFromJson(response);
		}

		public virtual async Task<List<Charge>> List(ChargeListOptions options = null)
		{
			var url = Urls.Charges;
			url = this.ApplyAllParameters(options, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Charge>.MapCollectionFromJson(response);
		}

		public virtual async Task<Charge> Capture(string chargeId, int? captureAmount = null, int? applicationFee = null)
		{
			var url = string.Format("{0}/{1}/capture", Urls.Charges, chargeId);
			url = this.ApplyAllParameters(null, url, false);

			if (captureAmount.HasValue)
			{
				url = ParameterBuilder.ApplyParameterToUrl(url, "amount", captureAmount.Value.ToString(CultureInfo.InvariantCulture));
			}

			if (applicationFee.HasValue)
			{
				url = ParameterBuilder.ApplyParameterToUrl(url, "application_fee", applicationFee.Value.ToString(CultureInfo.InvariantCulture));
			}

			var response = await Requestor.Post(url);

			return Mapper<Charge>.MapFromJson(response);
		}
	}
}