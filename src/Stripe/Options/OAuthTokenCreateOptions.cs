#region

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class OAuthTokenCreateOptions
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("client_secret")]
		public string ClientSecret { get; set; }

		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }

		[JsonProperty("grant_type")]
		public string GrantType { get; set; }

		[JsonProperty("scope")]
		public string Scope { get; set; }
	}
}