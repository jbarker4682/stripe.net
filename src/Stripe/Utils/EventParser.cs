#region

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Stripe.Entities;

#endregion

namespace Stripe.Utils
{
	public static class EventParser
	{
		public static Event ParseEvent(string json)
		{
			return Mapper<Event>.MapFromJson(json);
		}

		public static T ParseEventDataItem<T>(dynamic dataItem)
		{
			var jObject = dataItem as JObject;
			return jObject == null ? default(T) : JsonConvert.DeserializeObject<T>(jObject.ToString());
		}
	}
}