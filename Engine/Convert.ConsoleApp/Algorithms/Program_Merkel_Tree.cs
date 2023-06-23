using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
namespace ExerciseApp.ConsoleApp.Algorithms
{
	internal class Pprogram_Merkel_Tree
	{
	}


public class MerkleTree
	{
		private List<string> leaves;
		private List<string> tree;

		public MerkleTree(List<string> data)
		{
			leaves = data;
			tree = new List<string>();
			BuildTree();
		}

		public string GetRootHash()
		{
			if (tree.Count > 0)
			{
				return tree[0];
			}
			return null;
		}

		public bool Verify(string data, string proof)
		{
			// Calculate the hash of the data
			string dataHash = CalculateHash(data);

			// Verify the proof by comparing the computed root hash with the given proof
			return VerifyProof(dataHash, proof);
		}

		private void BuildTree()
		{
			// Convert the leaf data into leaf hashes
			List<string> leafHashes = ConvertToLeafHashes();

			// Build the Merkle tree bottom-up
			tree.AddRange(leafHashes);

			int levelSize = leafHashes.Count;
			while (levelSize > 1)
			{
				List<string> currentLevel = new List<string>();

				for (int i = 0; i < levelSize; i += 2)
				{
					string leftChild = tree[tree.Count - levelSize + i];
					string rightChild = (i + 1 < levelSize) ? tree[tree.Count - levelSize + i + 1] : leftChild;
					string parentHash = CalculateParentHash(leftChild, rightChild);

					currentLevel.Add(parentHash);
				}

				tree.AddRange(currentLevel);
				levelSize = currentLevel.Count;
			}
		}

		private List<string> ConvertToLeafHashes()
		{
			List<string> leafHashes = new List<string>();

			foreach (string leafData in leaves)
			{
				// Calculate the hash of each leaf data
				string leafHash = CalculateHash(leafData);
				leafHashes.Add(leafHash);
			}

			return leafHashes;
		}

		private string CalculateParentHash(string leftChild, string rightChild)
		{
			// Concatenate the left and right child hashes
			string concatenatedHash = leftChild + rightChild;

			// Calculate the hash of the concatenated string
			return CalculateHash(concatenatedHash);
		}

		private bool VerifyProof(string dataHash, string proof)
		{
			string computedRootHash = dataHash;

			// Iterate over the proof from left to right
			for (int i = 0; i < proof.Length; i += 64) // Assuming proof elements are 64-character hashes
			{
				string proofElement = proof.Substring(i, 64);

				// Reconstruct the parent hash using the current proof element and the computed root hash
				computedRootHash = CalculateParentHash(computedRootHash, proofElement);
			}

			// Compare the computed root hash with the actual root hash
			return (computedRootHash == GetRootHash());
		}

		private string CalculateHash(string data)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
				byte[] hashBytes = sha256.ComputeHash(dataBytes);

				return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
			}
		}
		public string GetProof(string data)
		{
			// Calculate the hash of the data
			string dataHash = CalculateHash(data);

			// Find the index of the data in the leaves list
			int dataIndex = leaves.IndexOf(data);
			if (dataIndex == -1)
			{
				return null; // Data not found
			}

			// Start building the proof from the leaf level
			List<string> proof = new List<string>();
			int levelSize = leaves.Count;

			int currentDataIndex = dataIndex;
			int currentLevelIndex = 0;

			while (levelSize > 1)
			{
				int siblingIndex = GetSiblingIndex(currentDataIndex, levelSize);

				if (siblingIndex != -1)
				{
					string siblingHash = tree[tree.Count - levelSize + siblingIndex];
					proof.Add(siblingHash);
				}

				currentDataIndex = currentDataIndex / 2;
				currentLevelIndex += levelSize;
				levelSize = (levelSize + 1) / 2;
			}

			return string.Join("", proof);
		}
		private int GetSiblingIndex(int dataIndex, int levelSize)
		{
			if (dataIndex % 2 == 0)
			{
				return dataIndex + 1;
			}
			else if (dataIndex + 1 < levelSize)
			{
				return dataIndex - 1;
			}

			return -1; // No sibling available
		}
	}

	public class Program_MerkleTree
	{
		public static void Main_MerkleTree(string[] args)
		{
			List<string> data = new List<string> { "Transaction 1", "Transaction 2", "Transaction 3", "Transaction 4" };

			MerkleTree merkleTree = new MerkleTree(data);

			string rootHash = merkleTree.GetRootHash();
			Console.WriteLine($"Root hash: {rootHash}");

			string transaction = "Transaction 2";
			string proof = merkleTree.GetProof(transaction);
			Console.WriteLine($"Proof for {transaction}: {proof}");

			bool verified = merkleTree.Verify(transaction, proof);
			Console.WriteLine($"Verification result: {verified}");
		}
	}

}
