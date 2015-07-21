using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Options;
using Stripe.Utils;

namespace Stripe.Services
{
	public class AccountService : BaseService
	{
		public virtual async Task<Account> Get(string id)
		{
			var url = string.Format(Urls.SpecificAccount, id);

			var response = await Requestor.Get(url);

			return Mapper<Account>.MapFromJson(response);
		}

		public virtual async Task<Account> Create(AccountCreateOptions createOptions)
		{
			var postData = this.ApplyAllParameters(createOptions, string.Empty, false);

			//remove the ?
			postData = RemoveQuestionMark(postData);

			var response = await Requestor.Post(Urls.Accounts, data: postData);

			return Mapper<Account>.MapFromJson(response);
		}

		public virtual async Task<Account> Update(string id, AccountUpdateOptions updateOptions)
		{
			var postData = this.ApplyAllParameters(updateOptions, string.Empty, false);

			//remove the ?
			postData = RemoveQuestionMark(postData);

			var response = await Requestor.Post(string.Format(Urls.SpecificAccount, id), data: postData);

			return Mapper<Account>.MapFromJson(response);
		}

		private static string RemoveQuestionMark(string source)
		{
			var index = source.IndexOf("?", System.StringComparison.Ordinal);
			var clean = (index < 0) ? source : source.Remove(index, "?".Length);
			return clean;
		}
	}
}