#region

using System;

using Newtonsoft.Json.Linq;

using Stripe.Entities;

#endregion

namespace Stripe.Internal
{
	internal static class ExpandableProperty<T> where T : BaseEntity
	{
		public static void Map(object value, Action<string> updateId, Action<T> updateObject)
		{
			var o = value as JObject;
			if (o != null)
			{
				var item = o.ToObject<T>();
				updateId(item.Id);
				updateObject(item);
			}
			else
			{
				var s = value as string;
				if (s == null)
				{
					return;
				}

				updateId(s);
				updateObject(null);
			}
		}
	}
}