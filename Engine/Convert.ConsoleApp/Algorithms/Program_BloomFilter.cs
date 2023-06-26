using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Algorithms
{


	public class BloomFilter
	{
		private bool[] filter;
		private int size;
		private int numHashFunctions;

		public BloomFilter(int size, int numHashFunctions)
		{
			this.size = size;
			this.numHashFunctions = numHashFunctions;
			filter = new bool[size];
		}

		public void Add(string item)
		{
			// Calculate hash values for the item
			int[] hashValues = GetHashValues(item);

			// Set the corresponding filter positions to true
			foreach (int hash in hashValues)
			{
				filter[hash] = true;
			}
		}

		public bool Contains(string item)
		{
			// Calculate hash values for the item
			int[] hashValues = GetHashValues(item);

			// Check if all corresponding filter positions are true
			foreach (int hash in hashValues)
			{
				if (!filter[hash])
				{
					return false;
				}
			}

			return true;
		}

		private int[] GetHashValues(string item)
		{
			int[] hashValues = new int[numHashFunctions];

			// Use different hash functions to generate multiple hash values
			for (int i = 0; i < numHashFunctions; i++)
			{
				// Combine the item's hash code and the iteration count to create a unique hash value
				hashValues[i] = (item.GetHashCode() + i) % size;
			}

			return hashValues;
		}
	}

	public class Program_BloomFilter
	{
		//public static void Main_BloomFilter(string[] args)
		public static void Main(string[] args)
		{
			// Create a Bloom filter with a size of 100 and 3 hash functions
			BloomFilter bloomFilter = new BloomFilter(100, 3);

			// Add items to the Bloom filter
			bloomFilter.Add("apple");
			bloomFilter.Add("banana");
			bloomFilter.Add("orange");

			// Check if items are present in the Bloom filter
			Console.WriteLine(bloomFilter.Contains("apple"));    // true
			Console.WriteLine(bloomFilter.Contains("banana"));   // true
			Console.WriteLine(bloomFilter.Contains("orange"));   // true
			Console.WriteLine(bloomFilter.Contains("grape"));    // false
			Console.WriteLine(bloomFilter.Contains("watermelon"));// false
		}
	}

}
