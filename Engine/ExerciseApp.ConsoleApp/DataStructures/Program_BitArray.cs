using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.DataStructures
{
	public class BitArray
	{
		private byte[] data;

		public BitArray(int size)
		{
			if (size <= 0)
				throw new ArgumentException("Size must be a positive integer.");

			int byteCount = (size + 7) / 8; // Calculate the number of bytes needed
			data = new byte[byteCount];
		}

		public bool this[int index]
		{
			get
			{
				int byteIndex = index / 8;
				int bitIndex = index % 8;

				byte mask = (byte)(1 << bitIndex);
				return (data[byteIndex] & mask) != 0;
			}
			set
			{
				int byteIndex = index / 8;
				int bitIndex = index % 8;

				byte mask = (byte)(1 << bitIndex);
				if (value)
					data[byteIndex] |= mask;
				else
					data[byteIndex] &= (byte)~mask;
			}
		}
	}

	public class Program
	{
		public static void Main()
		{
			BitArray bits = new BitArray(16);

			// Set some bits
			bits[1] = true;
			bits[4] = true;
			bits[9] = true;
			bits[12] = true;

			// Get the value of some bits
			Console.WriteLine(bits[1]);  // Output: True
			Console.WriteLine(bits[2]);  // Output: False

			// Print the bit array
			for (int i = 0; i < 16; i++)
			{
				Console.WriteLine($"Bit at index {i}: {bits[i]}");
			}
			Console.ReadLine();
		}
	}

	//public class Program_BitArray
	//{
	//	public static void main()
	//	{

	//	}
	//}
}
