#region

using System.Configuration;

#endregion

namespace Stripe.Internal
{
	internal static class StripeConfiguration
	{
		public static string ApiVersion = "2015-07-13";

		private static string _apiKey;

		internal static string ApiKey
		{
			get
			{
				if (string.IsNullOrEmpty(_apiKey))
				{
					_apiKey = ConfigurationManager.AppSettings["StripeApiKey"];
				}

				return _apiKey;
			}
		}
	}
}