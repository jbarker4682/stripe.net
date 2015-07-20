#region

using Newtonsoft.Json;

#endregion

namespace Stripe.Entities
{
	public class EventData
	{
		[JsonProperty("previous_attributes")]
		public dynamic PreviousAttributes { get; set; }

		[JsonProperty("object")]
		public dynamic Object { get; set; }
	}
}