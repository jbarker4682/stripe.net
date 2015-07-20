#region

using System.Collections.Generic;

using Newtonsoft.Json;

#endregion

namespace Stripe.Options
{
	public class PlanUpdateOptions
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }
	}
}