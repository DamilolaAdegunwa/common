using System;
using System.Security.Cryptography;
namespace ApiAuthorizationDbContextWebApplication.Services
{
	public class SecretKeyGenerator
	{
		public static void GenerateSecretKey()
		{
			// Generate a random secret key
			byte[] secretKey = GenerateSecretKey(32);

			// Convert the secret key to a string for storage or transmission
			string secretKeyString = Convert.ToBase64String(secretKey);

			Console.WriteLine("Generated Secret Key: " + secretKeyString);
		}

		private static byte[] GenerateSecretKey(int keyLength)
		{
			using (var rng = new RNGCryptoServiceProvider())
			{
				byte[] secretKey = new byte[keyLength];
				rng.GetBytes(secretKey);
				return secretKey;
			}
		}
	}
}
