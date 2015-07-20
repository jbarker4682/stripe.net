using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Utils;

namespace Stripe.Services
{
	public class AccountService : BaseService
	{
		public virtual async Task<Account> Get()
		{
			var response = await Requestor.Get(Urls.Account);
			return Mapper<Account>.MapFromJson(response);
		}
	}
}