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
	public class SubscriptionService : BaseService
	{
		public bool ExpandCustomer { get; set; }

		public virtual async Task<Subscription> Get(string customerId, string subscriptionId)
		{
			var url = string.Format(Urls.Subscriptions + "/{1}", customerId, subscriptionId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Subscription>.MapFromJson(response);
		}

		public virtual async Task<Subscription> Create(string customerId, string planId, SubscriptionCreateOptions createOptions = null)
		{
			var url = string.Format(Urls.Subscriptions, customerId);
			url = this.ApplyAllParameters(createOptions, url, false);
			url = ParameterBuilder.ApplyParameterToUrl(url, "plan", planId);

			var response = await Requestor.Post(url);

			return Mapper<Subscription>.MapFromJson(response);
		}

		public virtual async Task<Subscription> Update(string customerId, string subscriptionId, SubscriptionUpdateOptions updateOptions)
		{
			var url = string.Format(Urls.Subscriptions + "/{1}", customerId, subscriptionId);
			url = this.ApplyAllParameters(updateOptions, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Subscription>.MapFromJson(response);
		}

		public virtual async Task<Subscription> Cancel(string customerId, string subscriptionId, bool cancelAtPeriodEnd = false)
		{
			var url = string.Format(Urls.Subscriptions + "/{1}", customerId, subscriptionId);
			url = ParameterBuilder.ApplyParameterToUrl(url, "at_period_end", cancelAtPeriodEnd.ToString());

			var response = await Requestor.Delete(url);

			return Mapper<Subscription>.MapFromJson(response);
		}

		public virtual async Task<IEnumerable<Subscription>> List(string customerId, StripeListOptions listOptions = null)
		{
			var url = string.Format(Urls.Subscriptions, customerId);
			url = this.ApplyAllParameters(listOptions, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Subscription>.MapCollectionFromJson(response);
		}
	}
}