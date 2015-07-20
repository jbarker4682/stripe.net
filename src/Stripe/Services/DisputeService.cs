#region

using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Utils;

#endregion

namespace Stripe.Services
{
	public class DisputeService : BaseService
	{
		public bool ExpandCharge { get; set; }
		public bool ExpandBalanceTransaction { get; set; }

		public virtual async Task<Dispute> Update(string chargeId, string evidence = null)
		{
			var url = string.Format("{0}/dispute", chargeId);
			url = this.ApplyAllParameters(null, url, false);

			if (!string.IsNullOrEmpty(evidence))
			{
				url = ParameterBuilder.ApplyParameterToUrl(url, "evidence", evidence);
			}

			var response = await Requestor.Post(url);

			return Mapper<Dispute>.MapFromJson(response);
		}
	}
}