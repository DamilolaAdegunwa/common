using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp
{
	public class Geohash
	{
		private const int MaxGeohashLength = 12; // Maximum length of geohash (precision)

		// Base32 encoding characters
		private const string Base32Characters = "0123456789bcdefghjkmnpqrstuvwxyz";

		// Base32 decoding dictionary
		private static readonly char[] Base32DecodingDictionary = Base32Characters.ToCharArray();

		// Latitude range: -90 to 90, Longitude range: -180 to 180
		private const double MinLatitude = -90.0;
		private const double MaxLatitude = 90.0;
		private const double MinLongitude = -180.0;
		private const double MaxLongitude = 180.0;

		// Precision of latitude and longitude (bits)
		private const int LatitudePrecision = 20;
		private const int LongitudePrecision = 20;

		// Precision of each character in geohash (bits)
		private const int BitsPerCharacter = 5;

		// Calculating the precision (latitude and longitude) for each character
		private static readonly double LatitudePrecisionPerCharacter = (MaxLatitude - MinLatitude) / Math.Pow(2, BitsPerCharacter);
		private static readonly double LongitudePrecisionPerCharacter = (MaxLongitude - MinLongitude) / Math.Pow(2, BitsPerCharacter);

		public static string Encode(double latitude, double longitude, int precision = MaxGeohashLength)
		{
			if (precision <= 0 || precision > MaxGeohashLength)
			{
				throw new ArgumentOutOfRangeException(nameof(precision), $"Precision must be between 1 and {MaxGeohashLength}.");
			}

			if (latitude < MinLatitude || latitude > MaxLatitude)
			{
				throw new ArgumentOutOfRangeException(nameof(latitude), $"Latitude must be between {MinLatitude} and {MaxLatitude}.");
			}

			if (longitude < MinLongitude || longitude > MaxLongitude)
			{
				throw new ArgumentOutOfRangeException(nameof(longitude), $"Longitude must be between {MinLongitude} and {MaxLongitude}.");
			}

			string geohash = string.Empty;
			double minLat = MinLatitude;
			double maxLat = MaxLatitude;
			double minLon = MinLongitude;
			double maxLon = MaxLongitude;

			for (int i = 0; i < precision; i++)
			{
				int hashValue = 0;
				for (int j = 0; j < BitsPerCharacter; j++)
				{
					int bit = (i * BitsPerCharacter) + j;
					double mid;

					if (bit % 2 == 0) // Longitude bits
					{
						mid = (minLon + maxLon) / 2;
						if (longitude > mid)
						{
							hashValue = (hashValue << 1) + 1;
							minLon = mid;
						}
						else
						{
							hashValue <<= 1;
							maxLon = mid;
						}
					}
					else // Latitude bits
					{
						mid = (minLat + maxLat) / 2;
						if (latitude > mid)
						{
							hashValue = (hashValue << 1) + 1;
							minLat = mid;
						}
						else
						{
							hashValue <<= 1;
							maxLat = mid;
						}
					}
				}

				geohash += Base32DecodingDictionary[hashValue];
			}

			return geohash;
		}

		public static (double Latitude, double Longitude) Decode(string geohash)
		{
			if (string.IsNullOrEmpty(geohash))
			{
				throw new ArgumentNullException(nameof(geohash));
			}

			double minLat = MinLatitude;
			double maxLat = MaxLatitude;
			double minLon = MinLongitude;
			double maxLon = MaxLongitude;

			foreach (char c in geohash)
			{
				int hashValue = Array.IndexOf(Base32DecodingDictionary, c);
				if (hashValue == -1)
				{
					throw new ArgumentException($"Invalid geohash character '{c}'.");
				}

				for (int i = 0; i < BitsPerCharacter; i++)
				{
					int bit = BitsPerCharacter - i - 1;
					if (bit % 2 == 0)
					{
						if ((hashValue & (1 << bit)) != 0)
						{
							minLon = (minLon + maxLon) / 2;
						}
						else
						{
							maxLon = (minLon + maxLon) / 2;
						}
					}
					else
					{
						if ((hashValue & (1 << bit)) != 0)
						{
							minLat = (minLat + maxLat) / 2;
						}
						else
						{
							maxLat = (minLat + maxLat) / 2;
						}
					}
				}
			}

			double latitude = (minLat + maxLat) / 2;
			double longitude = (minLon + maxLon) / 2;

			return (latitude, longitude);
		}

		public static void Main()
		{
			//coordinates for Lagos, Nigeria (6.465422, 3.406448)
			var enc = Encode(6.465422, 3.406448);
			Console.WriteLine(enc);
			//done
		}
	}

}
