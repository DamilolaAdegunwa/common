using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//4th algorithm
namespace ExerciseApp.ConsoleApp.Algorithms
{
public class LeakyBucket
	{
		private int capacity; // Maximum number of tokens the bucket can hold
		private int rate; // Rate at which tokens are added to the bucket per second
		private int tokens; // Current number of tokens in the bucket
		private DateTime lastLeakTime; // Last time the bucket was leaked

		public LeakyBucket(int capacity, int rate)
		{
			this.capacity = capacity;
			this.rate = rate;
			tokens = 0;
			lastLeakTime = DateTime.UtcNow;
		}

		// Add tokens to the bucket
		public bool AddTokens(int count)
		{
			// Leak the bucket to account for time passed since the last leak
			Leak();

			// Check if adding tokens would exceed the capacity
			if (tokens + count <= capacity)
			{
				tokens += count;
				return true; // Tokens added successfully
			}

			return false; // Bucket is full, tokens cannot be added
		}

		// Consume tokens from the bucket
		public bool ConsumeTokens(int count)
		{
			// Leak the bucket to account for time passed since the last leak
			Leak();

			// Check if there are enough tokens to consume
			if (count <= tokens)
			{
				tokens -= count;
				return true; // Tokens consumed successfully
			}

			return false; // Not enough tokens available for consumption
		}

		// Leak the bucket to account for time passed since the last leak
		private void Leak()
		{
			DateTime currentTime = DateTime.UtcNow;
			double timePassedInSeconds = (currentTime - lastLeakTime).TotalSeconds;

			// Calculate the number of tokens that should be leaked
			int leakedTokens = (int)(timePassedInSeconds * rate);

			// Update the last leak time
			lastLeakTime = currentTime;

			// Leak tokens from the bucket
			tokens = Math.Max(0, tokens - leakedTokens);
		}
	}

	public class Program_LeakyBucket
	{
		public static void Main_LeakyBucket(string[] args)
		{
			// Create a leaky bucket with a capacity of 10 tokens and a rate of 2 tokens per second
			LeakyBucket leakyBucket = new LeakyBucket(10, 2);

			// Add 8 tokens to the bucket
			bool tokensAdded = leakyBucket.AddTokens(8);
			Console.WriteLine($"Tokens added to the bucket: {tokensAdded}");

			// Consume 5 tokens from the bucket
			bool tokensConsumed = leakyBucket.ConsumeTokens(5);
			Console.WriteLine($"Tokens consumed from the bucket: {tokensConsumed}");

			// Add 6 tokens to the bucket
			tokensAdded = leakyBucket.AddTokens(6);
			Console.WriteLine($"Tokens added to the bucket: {tokensAdded}");

			// Consume 10 tokens from the bucket
			tokensConsumed = leakyBucket.ConsumeTokens(10);
			Console.WriteLine($"Tokens consumed from the bucket: {tokensConsumed}");
		}
	}

}
