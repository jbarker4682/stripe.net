#region

using System.Collections.Generic;
using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Options;
using Stripe.Utils;

#endregion

namespace Stripe.Services
{
	public class EventService : BaseService
	{
		public virtual async Task<Event> Get(string eventId)
		{
			var url = string.Format("{0}/{1}", Urls.Events, eventId);

			var response = await Requestor.Get(url);

			return Mapper<Event>.MapFromJson(response);
		}

		public virtual async Task<IEnumerable<Event>> List(EventListOptions listOptions = null)
		{
			var url = Urls.Events;
			url = this.ApplyAllParameters(listOptions, url, true);

			var response = await Requestor.Get(url);

			return Mapper<Event>.MapCollectionFromJson(response);
		}
	}
}