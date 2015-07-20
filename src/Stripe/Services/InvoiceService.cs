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
	public class InvoiceService : BaseService
	{
		public bool ExpandCharge { get; set; }
		public bool ExpandCustomer { get; set; }

		public virtual async Task<Invoice> Get(string invoiceId)
		{
			var url = string.Format("{0}/{1}", Urls.Invoices, invoiceId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<Invoice>.MapFromJson(response);
		}

		public virtual async Task<Invoice> Upcoming(string customerId, string subscriptionId = null)
		{
			var url = string.Format("{0}/{1}", Urls.Invoices, "upcoming");

			url = ParameterBuilder.ApplyParameterToUrl(url, "customer", customerId);

			if (!String.IsNullOrEmpty(subscriptionId))
			{
				url = ParameterBuilder.ApplyParameterToUrl(url, "subscription", subscriptionId);
			}

			var response = await Requestor.Get(url);

			return Mapper<Invoice>.MapFromJson(response);
		}

		public virtual async Task<Invoice> Update(string invoiceId, InvoiceUpdateOptions options)
		{
			var url = string.Format("{0}/{1}", Urls.Invoices, invoiceId);
			url = this.ApplyAllParameters(options, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Invoice>.MapFromJson(response);
		}

		public virtual async Task<Invoice> Pay(string invoiceId)
		{
			var url = string.Format("{0}/{1}/pay", Urls.Invoices, invoiceId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Invoice>.MapFromJson(response);
		}

		public virtual async Task<IEnumerable<Invoice>> List(InvoiceListOptions options = null)
		{
			var url = Urls.Invoices;
			url = this.ApplyAllParameters(options, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Invoice>.MapCollectionFromJson(response);
		}

		public virtual async Task<Invoice> Create(string customerId, InvoiceCreateOptions options = null)
		{
			var url = Urls.Invoices;
			url = ParameterBuilder.ApplyParameterToUrl(url, "customer", customerId);
			url = this.ApplyAllParameters(options, url, false);

			var response = await Requestor.Post(url);

			return Mapper<Invoice>.MapFromJson(response);
		}
	}
}