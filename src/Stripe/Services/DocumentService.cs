using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Stripe.Entities;
using Stripe.Internal;
using Stripe.Utils;

namespace Stripe.Services
{
	public class DocumentsService : BaseService
	{
		private const string FORM_KEY = "file";

		private static string MimeType(string path)
		{
			switch (Path.GetExtension(path))
			{
				case ".png":
					return "image/png";

				case ".pdf":
					return "application/pdf";

				case ".jpg":
					return "image/jpeg";

				case ".jpeg":
					return "image/jpeg";

				default:
					return string.Empty;
			}
		}

		public virtual async Task<StripeDocument> UploadIdentityDocument(Stream file, string fileName)
		{
			var postData = new Dictionary<string, string>
			{
				{"purpose", "identity_document"}
			};

			var response = await Requestor.PostMultipartFormString(Urls.Uploads, postData, file, fileName, MimeType(fileName), FORM_KEY);

			return Mapper<StripeDocument>.MapFromJson(response);
		}

		public virtual async Task<StripeDocument> UploadDisputeEvidence(Stream file, string fileName)
		{
			var postData = new Dictionary<string, string>
			{
				{"purpose", "dispute_evidence"}
			};

			var response = await Requestor.PostMultipartFormString(Urls.Uploads, postData, file, fileName, MimeType(fileName), FORM_KEY);

			return Mapper<StripeDocument>.MapFromJson(response);
		}
	}
}
