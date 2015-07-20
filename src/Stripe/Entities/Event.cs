#region

using System;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Event : BaseEntity
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("created"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? Created { get; set; }

		[JsonProperty("data")]
		public EventData Data { get; set; }

		[JsonProperty("livemode")]
		public bool LiveMode { get; set; }

		[JsonProperty("user_id")]
		public string UserId { get; set; }

		[JsonProperty("pending_webhooks")]
		public int PendingWebhooks { get; set; }

		[JsonProperty("request")]
		public string Request { get; set; }
	}
}