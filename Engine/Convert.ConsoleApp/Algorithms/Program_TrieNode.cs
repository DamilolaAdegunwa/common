using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
namespace ExerciseApp.ConsoleApp.Algorithms
{

	public class TrieNode
	{
		public bool IsEndOfWord { get; set; }
		public Dictionary<char, TrieNode> Children { get; }

		public TrieNode()
		{
			IsEndOfWord = false;
			Children = new Dictionary<char, TrieNode>();
		}
	}

	public class Trie
	{
		private TrieNode root;

		public Trie()
		{
			root = new TrieNode();
		}

		// Insert a word into the Trie
		public void Insert(string word)
		{
			TrieNode current = root;

			// Traverse the Trie, creating nodes as necessary
			foreach (char c in word)
			{
				if (!current.Children.ContainsKey(c))
				{
					current.Children[c] = new TrieNode();
				}

				current = current.Children[c];
			}

			// Mark the last node as the end of the word
			current.IsEndOfWord = true;
		}

		// Search for a word in the Trie
		public bool Search(string word)
		{
			TrieNode current = root;

			// Traverse the Trie, checking for each character
			foreach (char c in word)
			{
				if (!current.Children.ContainsKey(c))
				{
					return false; // Character not found, word does not exist
				}

				current = current.Children[c];
			}

			// Check if the last node represents the end of a word
			return current.IsEndOfWord;
		}

		// Check if a given prefix exists in the Trie
		public bool StartsWith(string prefix)
		{
			TrieNode current = root;

			// Traverse the Trie, checking for each character
			foreach (char c in prefix)
			{
				if (!current.Children.ContainsKey(c))
				{
					return false; // Character not found, prefix does not exist
				}

				current = current.Children[c];
			}

			return true; // All characters found, prefix exists
		}
	}

	public class Program_TrieNode
	{
		public static void Main_TrieNode(string[] args)
		{
			// Create a Trie
			Trie trie = new Trie();

			// Insert words into the Trie
			trie.Insert("apple");
			trie.Insert("banana");
			trie.Insert("car");
			trie.Insert("cat");
			trie.Insert("dog");

			// Search for words in the Trie
			Console.WriteLine($"Search 'apple': {trie.Search("apple")}");
			Console.WriteLine($"Search 'banana': {trie.Search("banana")}");
			Console.WriteLine($"Search 'car': {trie.Search("car")}");
			Console.WriteLine($"Search 'cat': {trie.Search("cat")}");
			Console.WriteLine($"Search 'dog': {trie.Search("dog")}");
			Console.WriteLine($"Search 'elephant': {trie.Search("elephant")}");

			// Check if prefixes exist in the Trie
			Console.WriteLine($"Starts with 'app': {trie.StartsWith("app")}");
			Console.WriteLine($"Starts with 'ba': {trie.StartsWith("ba")}");
			Console.WriteLine($"Starts with 'd': {trie.StartsWith("d")}");
			Console.WriteLine($"Starts with 'ca': {trie.StartsWith("ca")}");
			Console.WriteLine($"Starts with 'ze': {trie.StartsWith("ze")}");
		}
	}

}
