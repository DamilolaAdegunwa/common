using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;

//5th algo
namespace ExerciseApp.ConsoleApp.Algorithms
{
	//internal class Program_TokenBucket
	//{
	//}

public class TokenBucket
	{
		private int capacity; // Maximum number of tokens the bucket can hold
		private int tokens; // Current number of tokens in the bucket
		private int rate; // Rate at which tokens are added to the bucket per second
		private Timer timer; // Timer for adding tokens at a constant rate

		public TokenBucket(int capacity, int rate)
		{
			this.capacity = capacity;
			this.tokens = capacity; // Start with a full bucket
			this.rate = rate;
			this.timer = new Timer(AddToken, null, 1000, 1000); // Start the timer to add tokens every second
		}

		// Add tokens to the bucket
		private void AddToken(object state)
		{
			lock (this)
			{
				tokens = Math.Min(capacity, tokens + rate); // Add tokens up to the capacity
			}
		}

		// Consume tokens from the bucket
		public bool ConsumeTokens(int count)
		{
			lock (this)
			{
				if (count <= tokens)
				{
					tokens -= count;
					return true; // Tokens consumed successfully
				}

				return false; // Not enough tokens available for consumption
			}
		}
	}

	public class Program_TokenBucket
	{
		public static void Main_TokenBucket(string[] args)
		{
			// Create a token bucket with a capacity of 10 tokens and a rate of 2 tokens per second
			TokenBucket tokenBucket = new TokenBucket(10, 2);

			// Consume 5 tokens from the bucket
			bool tokensConsumed = tokenBucket.ConsumeTokens(5);
			Console.WriteLine($"Tokens consumed from the bucket: {tokensConsumed}");

			// Consume 8 tokens from the bucket
			tokensConsumed = tokenBucket.ConsumeTokens(8);
			Console.WriteLine($"Tokens consumed from the bucket: {tokensConsumed}");

			// Consume 3 tokens from the bucket
			tokensConsumed = tokenBucket.ConsumeTokens(3);
			Console.WriteLine($"Tokens consumed from the bucket: {tokensConsumed}");

			// Wait for a few seconds to allow tokens to be added
			Thread.Sleep(3000);

			// Consume 4 tokens from the bucket after waiting
			tokensConsumed = tokenBucket.ConsumeTokens(4);
			Console.WriteLine($"Tokens consumed from the bucket: {tokensConsumed}");
		}
	}

}
