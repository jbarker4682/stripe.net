#region

using Newtonsoft.Json;

#endregion

namespace Stripe.Entities
{
	public abstract class BaseEntity
	{
		[JsonProperty("id")]
		public string Id { get; set; }
	}
}