#region

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace Stripe.Internal
{
	internal class StripeDateTimeConverter : DateTimeConverterBase
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteRawValue(@"""\/Date(" + ((DateTime)value).ConvertDateTimeToEpoch() + @")\/""");
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.Value == null)
			{
				return null;
			}

			return reader.TokenType == JsonToken.Integer
				       ? EpochTime.ConvertEpochToDateTime((long)reader.Value)
				       : DateTime.Parse(reader.Value.ToString());
		}
	}
}