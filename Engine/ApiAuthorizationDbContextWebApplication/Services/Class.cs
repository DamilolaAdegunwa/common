using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace ApiAuthorizationDbContextWebApplication.Services
{
	public static class Validations
	{
		public static void DisableCertificateValidation()
		{
			// Attach the custom certificate validation callback
			ServicePointManager.ServerCertificateValidationCallback += IgnoreCertificateValidation;
		}

		private static bool IgnoreCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			// Ignore any certificate errors
			return true;
		}
	}
}
