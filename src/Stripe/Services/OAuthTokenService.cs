#region

using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Options;
using Stripe.Utils;

#endregion

namespace Stripe.Services
{
	public class OAuthTokenService : BaseService
	{
		public virtual async Task<OAuthToken> Create(OAuthTokenCreateOptions createOptions)
		{
			var url = this.ApplyAllParameters(createOptions, Urls.OAuthToken, false);

			var response = await Requestor.Post(url, true);

			return Mapper<OAuthToken>.MapFromJson(response);
		}
	}
}