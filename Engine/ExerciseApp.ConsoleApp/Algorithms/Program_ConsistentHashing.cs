using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

//3
namespace ExerciseApp.ConsoleApp.Algorithms
{
    public class ConsistentHashing<T>
    {
        private readonly SortedDictionary<uint, T> circle; // Sorted dictionary representing the hash ring
        private readonly int replicaCount; // Number of replicas for each node

        public ConsistentHashing(int replicaCount)
        {
            this.replicaCount = replicaCount;
            circle = new SortedDictionary<uint, T>();
            //circle.Keys;
        }

        // Add a node to the hash ring
        public void AddNode(T node)
        {
            for (int i = 0; i < replicaCount; i++)
            {
                // Generate a unique key for each replica of the node
                byte[] bytes = Guid.NewGuid().ToByteArray();
                uint hash = BitConverter.ToUInt32(bytes, 0);

                // Add the key and node to the hash ring
                circle[hash] = node;
            }
        }

        // Remove a node from the hash ring
        public void RemoveNode(T node)
        {
            List<uint> keysToRemove = new List<uint>();

            foreach (KeyValuePair<uint, T> entry in circle)
            {
                if (entry.Value.Equals(node))
                {
                    keysToRemove.Add(entry.Key);
                }
            }

            foreach (uint key in keysToRemove)
            {
                circle.Remove(key);
            }
        }

        // Get the node responsible for handling a given key
        public T GetNode(string key)
        {
            if (circle.Count == 0)
            {
                throw new InvalidOperationException("No nodes available in the hash ring.");
            }

            // Compute the hash of the key
            byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(key));
            uint hash = BitConverter.ToUInt32(bytes, 0);

            // Find the node responsible for handling the key
            foreach (KeyValuePair<uint, T> entry in circle)
            {
                if (hash <= entry.Key)
                {
                    return entry.Value;
                }
            }

            // If the key hash is greater than the largest node hash, wrap around to the first node
            //return circle[circle.Keys[0]];
            return circle[circle.Keys.FirstOrDefault()];
            //return circle[0];
        }
    }

    public class Program_ConsistentHashing
    {
        public static void Main_ConsistentHashing(string[] args)
        {
            // Create a consistent hashing object with 3 replicas per node
            ConsistentHashing<string> consistentHashing = new ConsistentHashing<string>(3);

            // Add nodes to the hash ring
            consistentHashing.AddNode("Node A");
            consistentHashing.AddNode("Node B");
            consistentHashing.AddNode("Node C");

            // Get the node responsible for handling a given key
            string key1 = "Key 1";
            string key2 = "Key 2";
            string key3 = "Key 3";
            string key4 = "Key 4";

            string node1 = consistentHashing.GetNode(key1);
            string node2 = consistentHashing.GetNode(key2);
            string node3 = consistentHashing.GetNode(key3);
            string node4 = consistentHashing.GetNode(key4);

            Console.WriteLine($"Key '{key1}' is assigned to node: {node1}");
            Console.WriteLine($"Key '{key2}' is assigned to node: {node2}");
            Console.WriteLine($"Key '{key3}' is assigned to node: {node3}");
            Console.WriteLine($"Key '{key4}' is assigned to node: {node4}");

            // Remove a node from the hash ring
            consistentHashing.RemoveNode("Node B");

            // Get the node responsible for handling the same keys after removing a node
            string newNode1 = consistentHashing.GetNode(key1);
            string newNode2 = consistentHashing.GetNode(key2);
            string newNode3 = consistentHashing.GetNode(key3);
            string newNode4 = consistentHashing.GetNode(key4);

            Console.WriteLine($"Key '{key1}' is assigned to node: {newNode1} (after removing a node)");
            Console.WriteLine($"Key '{key2}' is assigned to node: {newNode2} (after removing a node)");
            Console.WriteLine($"Key '{key3}' is assigned to node: {newNode3} (after removing a node)");
            Console.WriteLine($"Key '{key4}' is assigned to node: {newNode4} (after removing a node)");
        }
    }

}
