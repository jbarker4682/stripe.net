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
	public class BalanceService : BaseService
	{
		public virtual async Task<Balance> Get()
		{
			var response = await Requestor.Get(Urls.Balance);

			return Mapper<Balance>.MapFromJson(response);
		}

		public virtual async Task<BalanceTransaction> Get(string id)
		{
			var url = string.Format(Urls.SpecificBalanceTransaction, id);
			url = this.ApplyAllParameters(null, url, false);

			var response = await Requestor.Get(url);

			return Mapper<BalanceTransaction>.MapFromJson(response);
		}

		public virtual async Task<IEnumerable<BalanceTransaction>> List(BalanceTransactionListOptions options = null)
		{
			var url = Urls.BalanceTransactions;
			url = this.ApplyAllParameters(options, url, true);

			var response = await Requestor.Get(url);

			return Mapper<BalanceTransaction>.MapCollectionFromJson(response);
		}
	}
}