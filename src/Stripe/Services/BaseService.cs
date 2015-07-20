using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Options;

namespace Stripe.Services
{
	public abstract class BaseService
	{
		public string ApplyAllParameters(object obj, string url, bool isListMethod)
		{
			var newUrl = url;

			if (obj != null)
			{
				foreach (var property in obj.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
				{
					var value = property.GetValue(obj, null);
					if (value == null)
					{
						continue;
					}

					foreach (var attribute in property.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
					{
						if (String.Compare(attribute.PropertyName, "metadata", StringComparison.OrdinalIgnoreCase) == 0)
						{
							var metadata = (Dictionary<string, string>)value;

							newUrl = metadata.Keys.Aggregate(newUrl, (current, key) =>
								ParameterBuilder.ApplyParameterToUrl(current, string.Format("metadata[{0}]", key), metadata[key]));
						}
						else if (property.PropertyType == typeof(DateFilter))
						{
							var filter = (DateFilter)value;

							if (filter.EqualTo.HasValue)
							{
								newUrl = ParameterBuilder.ApplyParameterToUrl(newUrl, attribute.PropertyName,
									filter.EqualTo.Value.ConvertDateTimeToEpoch().ToString(CultureInfo.InvariantCulture));
							}
							else if (filter.LessThan.HasValue)
							{
								newUrl = ParameterBuilder.ApplyParameterToUrl(newUrl, attribute.PropertyName + "[lt]",
									filter.LessThan.Value.ConvertDateTimeToEpoch().ToString(CultureInfo.InvariantCulture));
							}

							if (filter.LessThanOrEqual.HasValue)
							{
								newUrl = ParameterBuilder.ApplyParameterToUrl(newUrl, attribute.PropertyName + "[lte]",
									filter.LessThanOrEqual.Value.ConvertDateTimeToEpoch().ToString(CultureInfo.InvariantCulture));
							}

							if (filter.GreaterThan.HasValue)
							{
								newUrl = ParameterBuilder.ApplyParameterToUrl(newUrl, attribute.PropertyName + "[gt]",
									filter.GreaterThan.Value.ConvertDateTimeToEpoch().ToString(CultureInfo.InvariantCulture));
							}

							if (filter.GreaterThanOrEqual.HasValue)
							{
								newUrl = ParameterBuilder.ApplyParameterToUrl(newUrl, attribute.PropertyName + "[gte]",
									filter.GreaterThanOrEqual.Value.ConvertDateTimeToEpoch().ToString(CultureInfo.InvariantCulture));
							}
						}
						else if (property.PropertyType == typeof(BankAccountOptions))
						{
							var bankAccountOptions = (BankAccountOptions)value;
							newUrl = ParameterBuilder.ApplyNestedObjectProperties(newUrl, bankAccountOptions);
						}
						else if (property.PropertyType == typeof(CreditCardOptions))
						{
							var creditCardOptions = (CreditCardOptions)value;
							newUrl = ParameterBuilder.ApplyNestedObjectProperties(newUrl, creditCardOptions);
						}
						else if (property.PropertyType == typeof(SourceOptions))
						{
							var creditCardOptions = (SourceOptions)value;
							newUrl = ParameterBuilder.ApplyNestedObjectProperties(newUrl, creditCardOptions);
						}
						else
						{
							newUrl = ParameterBuilder.ApplyParameterToUrl(newUrl, attribute.PropertyName, value.ToString());
						}
					}
				}
			}

			var propertiesToExpand =
				this.GetType()
				    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
				    .Where(p => p.Name.StartsWith("Expand") && p.PropertyType == typeof(bool))
				    .Where(p => (bool)p.GetValue(this, null))
				    .Select(p => p.Name);

			foreach (var propertyName in propertiesToExpand)
			{
				var expandPropertyName = propertyName.Substring("Expand".Length);
				expandPropertyName = Regex.Replace(expandPropertyName, "([a-z])([A-Z])", "$1_$2").ToLower();

				if (isListMethod)
				{
					expandPropertyName = "data." + expandPropertyName;
				}

				newUrl = ParameterBuilder.ApplyParameterToUrl(newUrl, "expand[]", expandPropertyName);
			}

			return newUrl;
		}
	}
}
