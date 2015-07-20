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
	public class PlanService : BaseService
	{
		public virtual async Task<Plan> Create(PlanCreateOptions createOptions)
		{
			var url = this.ApplyAllParameters(createOptions, Urls.Plans, false);

			var response = await Requestor.Post(url);

			return Mapper<Plan>.MapFromJson(response);
		}

		public virtual async Task<Plan> Get(string planId)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Plan>.MapFromJson(response);
		}

		public virtual async void Delete(string planId)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);

			await Requestor.Delete(url);
		}

		public virtual async Task<Plan> Update(string planId, PlanUpdateOptions updateOptions)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);
			url = this.ApplyAllParameters(updateOptions, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Plan>.MapFromJson(response);
		}

		public virtual async Task<IEnumerable<Plan>> List(StripeListOptions listOptions = null)
		{
			var url = Urls.Plans;
			url = this.ApplyAllParameters(listOptions, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Plan>.MapCollectionFromJson(response);
		}
	}
}