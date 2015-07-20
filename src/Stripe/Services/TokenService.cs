#region

using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Options;
using Stripe.Utils;

#endregion

namespace Stripe.Services
{
	public class TokenService : BaseService
	{
		public virtual async Task<Token> Create(TokenCreateOptions createOptions)
		{
			var url = this.ApplyAllParameters(createOptions, Urls.Tokens, false);

			var response = await Requestor.Post(url);

			return Mapper<Token>.MapFromJson(response);
		}

		public virtual async Task<Token> Get(string tokenId)
		{
			var url = string.Format("{0}/{1}", Urls.Tokens, tokenId);

			var response = await Requestor.Get(url);

			return Mapper<Token>.MapFromJson(response);
		}
	}
}