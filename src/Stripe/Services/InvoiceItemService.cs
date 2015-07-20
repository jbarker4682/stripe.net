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
	public class InvoiceItemService : BaseService
	{
		public bool ExpandCustomer { get; set; }
		public bool ExpandInvoice { get; set; }

		public virtual async Task<InvoiceLineItem> Create(InvoiceItemCreateOptions options)
		{
			var url = this.ApplyAllParameters(options, Urls.InvoiceItems, false);

			var response = await Requestor.Post(url);

			return Mapper<InvoiceLineItem>.MapFromJson(response);
		}

		public virtual async Task<InvoiceLineItem> Get(string invoiceItemId)
		{
			var url = string.Format("{0}/{1}", Urls.InvoiceItems, invoiceItemId);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<InvoiceLineItem>.MapFromJson(response);
		}

		public virtual async Task<InvoiceLineItem> Update(string invoiceItemId, InvoiceItemUpdateOptions options)
		{
			var url = string.Format("{0}/{1}", Urls.InvoiceItems, invoiceItemId);
			url = this.ApplyAllParameters(options, url, false);

			var response = await Requestor.Post(url);

			return Mapper<InvoiceLineItem>.MapFromJson(response);
		}

		public virtual void Delete(string invoiceItemId)
		{
			var url = string.Format("{0}/{1}", Urls.InvoiceItems, invoiceItemId);

			Requestor.Delete(url);
		}

		public virtual async Task<IEnumerable<InvoiceLineItem>> List(InvoiceItemListOptions options = null)
		{
			var url = Urls.InvoiceItems;
			url = this.ApplyAllParameters(options, url, true);

			var response = await Requestor.Get(url);

			return Mapper<InvoiceLineItem>.MapCollectionFromJson(response);
		}
	}
}