using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ExerciseApp.ConsoleApp.Algorithms
{

	//internal class Program_Rsync
	//{
	//}

public class Rsync
	{
		// Function to calculate the rolling checksum of a block
		private static uint CalculateRollingChecksum(string block)
		{
			uint checksum = 0;
			foreach (char c in block)
			{
				checksum += c;
			}
			return checksum;
		}

		// Function to find the matching blocks between the source and target files
		private static List<int> FindMatchingBlocks(string source, string target, int blockSize)
		{
			List<int> matchingBlocks = new List<int>();

			int sourceLength = source.Length;
			int targetLength = target.Length;

			// Calculate the rolling checksum for each block in the source file
			Dictionary<uint, List<int>> sourceChecksums = new Dictionary<uint, List<int>>();
			for (int i = 0; i <= sourceLength - blockSize; i++)
			{
				string block = source.Substring(i, blockSize);
				uint checksum = CalculateRollingChecksum(block);

				if (!sourceChecksums.ContainsKey(checksum))
				{
					sourceChecksums[checksum] = new List<int>();
				}
				sourceChecksums[checksum].Add(i);
			}

			// Find matching blocks in the target file using rolling checksum
			for (int i = 0; i <= targetLength - blockSize; i++)
			{
				string block = target.Substring(i, blockSize);
				uint checksum = CalculateRollingChecksum(block);

				if (sourceChecksums.ContainsKey(checksum))
				{
					foreach (int sourceIndex in sourceChecksums[checksum])
					{
						string sourceBlock = source.Substring(sourceIndex, blockSize);
						if (sourceBlock == block)
						{
							matchingBlocks.Add(sourceIndex);
							break;
						}
					}
				}
			}

			return matchingBlocks;
		}

		// Function to synchronize the source and target files
		public static void Synchronize(string sourceFile, string targetFile)
		{
			// Simulating the source and target file contents
			string sourceContent = "This is the source file content.";
			string targetContent = "This is the modified target file content.";

			// Simulating block size and window size
			int blockSize = 4;
			int windowSize = 8;

			// Finding matching blocks between source and target files
			List<int> matchingBlocks = FindMatchingBlocks(sourceContent, targetContent, blockSize);

			// Synchronize the files based on matching blocks
			foreach (int blockIndex in matchingBlocks)
			{
				string block = sourceContent.Substring(blockIndex, blockSize);
				int startIndex = Math.Max(blockIndex - windowSize, 0);
				int endIndex = Math.Min(blockIndex + blockSize + windowSize, targetContent.Length - blockSize);

				// Check if the block exists in the window of the target file
				int targetIndex = targetContent.IndexOf(block, startIndex, endIndex - startIndex);
				if (targetIndex != -1)
				{
					// Copy the delta (non-matching portion) from the target file
					string delta = targetContent.Substring(startIndex, targetIndex - startIndex);
					Console.WriteLine($"Copy delta: '{delta}'");
				}
				else
				{
					// Block not found in the target file, send the entire block
					Console.WriteLine($"Send block: '{block}'");
				}
			}

			// Send the remaining content from the target file
			if((matchingBlocks.Count * blockSize) > targetContent.Length)
			{
				targetContent = targetContent.PadRight((matchingBlocks.Count * blockSize));
			}
			string remainingContent = targetContent.Substring(matchingBlocks.Count * blockSize);
			Console.WriteLine($"Send remaining content: '{remainingContent}'");
		}
	}

	public class Program_Rsync
	{
		[DoesNotReturn]
		public static void Main_Rsync(string[] args)
		{
			// Simulating synchronization between source and target files
			string sourceFile = "source.txt";
			string targetFile = "target.txt";
			Rsync.Synchronize(sourceFile, targetFile);
		}
	}

}
