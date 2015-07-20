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
	public class CustomerService : BaseService
	{
		public virtual async Task<Customer> Create(CustomerCreateOptions createOptions)
		{
			var url = this.ApplyAllParameters(createOptions, Urls.Customers, false);

			var response = await Requestor.Post(url);

			return Mapper<Customer>.MapFromJson(response);
		}

		public virtual async Task<Customer> Get(string customerId)
		{
			var url = string.Format("{0}/{1}", Urls.Customers, customerId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Customer>.MapFromJson(response);
		}

		public virtual async Task<Customer> Update(string customerId, CustomerUpdateOptions updateOptions)
		{
			var url = string.Format("{0}/{1}", Urls.Customers, customerId);
			url = this.ApplyAllParameters(updateOptions, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Customer>.MapFromJson(response);
		}

		public virtual async void Delete(string customerId)
		{
			var url = string.Format("{0}/{1}", Urls.Customers, customerId);

			await Requestor.Delete(url);
		}

		public virtual async Task<IEnumerable<Customer>> List(CustomerListOptions listOptions = null)
		{
			var url = Urls.Customers;
			url = this.ApplyAllParameters(listOptions, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Customer>.MapCollectionFromJson(response);
		}
	}
}