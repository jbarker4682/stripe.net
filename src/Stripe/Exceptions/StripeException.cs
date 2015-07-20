#region

using System;
using System.Net;

using Stripe.Entities;

#endregion

namespace Stripe.Exceptions
{
	[Serializable]
	public class StripeException : ApplicationException
	{
		public StripeException() {}

		public StripeException(HttpStatusCode httpStatusCode, StripeError stripeError, string message) : base(message)
		{
			this.HttpStatusCode = httpStatusCode;
			this.StripeError = stripeError;
		}

		public HttpStatusCode HttpStatusCode { get; set; }
		public StripeError StripeError { get; set; }
	}
}