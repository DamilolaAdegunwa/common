using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Algorithms
{

	public class CountMinSketch
	{
		private int[][] sketch;
		private int width;
		private int depth;
		private int[] hashCoefficients;

		public CountMinSketch(int width, int depth)
		{
			this.width = width;
			this.depth = depth;
			sketch = new int[depth][];
			hashCoefficients = new int[depth];

			// Initialize the sketch and hash coefficients
			for (int i = 0; i < depth; i++)
			{
				sketch[i] = new int[width];
				hashCoefficients[i] = GenerateHashCoefficient();
			}
		}

		public void Add(string item)
		{
			// Update the sketch for each hash function
			for (int i = 0; i < depth; i++)
			{
				int hash = Hash(item, hashCoefficients[i]);
				sketch[i][hash]++;
			}
		}

		public int EstimateFrequency(string item)
		{
			int minFrequency = int.MaxValue;

			// Find the minimum frequency among all hash functions
			for (int i = 0; i < depth; i++)
			{
				int hash = Hash(item, hashCoefficients[i]);
				minFrequency = Math.Min(minFrequency, sketch[i][hash]);
			}

			return minFrequency;
		}

		private int Hash(string item, int coefficient)
		{
			int hash = item.GetHashCode();
			return (hash ^ coefficient) % width;
		}

		private int GenerateHashCoefficient()
		{
			// In a real implementation, a suitable hash coefficient would be generated
			// For simplicity, we use a random coefficient within the range of Int32
			Random random = new Random();
			return random.Next();
		}
	}

	public class Program_CountMinSketch
	{
		public static void Main_CountMinSketch(string[] args)
		{
			// Create a Count-Min Sketch with width of 100 and depth of 5
			CountMinSketch countMinSketch = new CountMinSketch(100, 5);

			// Add items to the Count-Min Sketch
			countMinSketch.Add("apple");
			countMinSketch.Add("banana");
			countMinSketch.Add("orange");
			countMinSketch.Add("apple");
			countMinSketch.Add("banana");
			countMinSketch.Add("apple");

			// Estimate the frequencies of items
			Console.WriteLine("Frequency of 'apple': " + countMinSketch.EstimateFrequency("apple"));     // Expected: 3
			Console.WriteLine("Frequency of 'banana': " + countMinSketch.EstimateFrequency("banana"));   // Expected: 2
			Console.WriteLine("Frequency of 'orange': " + countMinSketch.EstimateFrequency("orange"));   // Expected: 1
			Console.WriteLine("Frequency of 'grape': " + countMinSketch.EstimateFrequency("grape"));     // Expected: 0 (item not added)
		}
	}

}
