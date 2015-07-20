#region

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class CardCreateOptions
	{
		[JsonProperty("source")]
		public SourceOptions Source { get; set; }
	}
}