using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp
{
	public class ArrayTest
	{
		/// <summary>
		/// testing for the maximum number of long array i can create
		/// </summary>
		//public static void Main()
		//{
		//	//long[] array = new long[2_147_483_591];
		//	long[] array = new long[int.MaxValue - 56];
		//	foreach (long i in array)
		//	{
		//		array[i] = long.MaxValue;
		//	}
		//	Console.WriteLine(array);
		//}

		/// <summary>
		/// testing for the maximum number of int array i can create
		/// </summary>
		public static void Main_ArrayTest()
		{
			//long[] array = new long[2_147_483_591];
			int[] array = new int[int.MaxValue - 56];
			foreach (int i in array)
			{
				array[i] = int.MaxValue;
			}
			Console.WriteLine(array);
		}
	}
}
