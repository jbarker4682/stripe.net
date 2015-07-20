#region

using System;

using Newtonsoft.Json;

using Stripe.Internal;

#endregion

namespace Stripe.Entities
{
	public class Discount : BaseEntity
	{
		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("coupon")]
		public Coupon Coupon { get; set; }

		[JsonProperty("start"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? Start { get; set; }

		[JsonProperty("end"), JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? End { get; set; }

		#region Expandable Customer

		public string CustomerId { get; set; }

		[JsonIgnore]
		public Customer Customer { get; set; }

		[JsonProperty("customer")]
		internal object InternalCustomer
		{
			set { ExpandableProperty<Customer>.Map(value, s => this.CustomerId = s, o => this.Customer = o); }
		}

		#endregion
	}
}