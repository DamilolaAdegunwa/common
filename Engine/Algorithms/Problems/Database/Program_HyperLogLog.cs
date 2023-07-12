using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Algorithms
{

	public class HyperLogLog
	{
		private int[] registers;
		private int m;
		private double alpha;

		public HyperLogLog(int precision)
		{
			m = 1 << precision;
			registers = new int[m];
			alpha = GetAlpha(m);
		}

		public void Add(string item)
		{
			// Calculate the hash value of the item
			int hash = item.GetHashCode();

			// Extract the index and value from the hash
			int index = hash >> (32 - GetPrecision());
			int value = GetRank(hash, GetPrecision());

			// Update the register if the value is greater than the current register value
			registers[index] = Math.Max(registers[index], value);
		}

		public int Count()
		{
			double estimate = Estimate();
			return (int)Math.Round(estimate);
		}

		private double Estimate()
		{
			double sum = 0;

			// Calculate the harmonic mean of the register values
			for (int i = 0; i < m; i++)
			{
				sum += 1.0 / (1 << registers[i]);
			}

			double estimate = alpha * m * m / sum;
			return estimate;
		}

		private int GetPrecision()
		{
			return (int)Math.Log2(m);
		}

		private int GetRank(int hash, int precision)
		{
			// Count the number of leading zeros in the hash value
			int rank = 1;

			while (((hash >> (31 - rank)) & 1) == 0 && rank <= precision)
			{
				rank++;
			}

			return rank;
		}

		private double GetAlpha(int m)
		{
			// Constants for different precision values
			if (m == 16) return 0.673;
			if (m == 32) return 0.697;
			if (m == 64) return 0.709;

			return 0.7213 / (1 + 1.079 / m);
		}
	}

	public class Program_HyperLogLog
	{
		public static void Main_HyperLogLog(string[] args)
		{
			// Create a HyperLogLog instance with precision 10
			HyperLogLog hyperLogLog = new HyperLogLog(10);

			// Add items to the HyperLogLog
			hyperLogLog.Add("apple");
			hyperLogLog.Add("banana");
			hyperLogLog.Add("orange");

			// Count the distinct items
			int count = hyperLogLog.Count();

			Console.WriteLine($"Distinct items: {count}"); // Output: Distinct items: 3
		}
	}

}
