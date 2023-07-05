using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.SystemSpan
{
	public class BasicSpanTest
	{
		public BasicSpanTest() { }
		public void Test1()
		{
			// Create a span over an array.
			var array = new byte[100];
			var arraySpan = new Span<byte>(array);

			byte data = 0;
			for (int ctr = 0; ctr < arraySpan.Length; ctr++)
				arraySpan[ctr] = data++;

			int arraySum = 0;
			foreach (var value in array)
				arraySum += value;

			Console.WriteLine($"The sum is {arraySum}");
			// Output:  The sum is 4950
		}

		public void Test2()
		{
			// Create a span from native memory.
			var native = Marshal.AllocHGlobal(100);
			Span<byte> nativeSpan;
			unsafe
			{
				nativeSpan = new Span<byte>(native.ToPointer(), 100);
			}
			byte data = 0;
			for (int ctr = 0; ctr < nativeSpan.Length; ctr++)
				nativeSpan[ctr] = data++;

			int nativeSum = 0;
			foreach (var value in nativeSpan)
				nativeSum += value;

			Console.WriteLine($"The sum is {nativeSum}");
			Marshal.FreeHGlobal(native);
			// Output:  The sum is 4950
		}

		public void Test3()
		{
			// Create a span on the stack.
			byte data = 0;
			Span<byte> stackSpan = stackalloc byte[100];
			for (int ctr = 0; ctr < stackSpan.Length; ctr++)
				stackSpan[ctr] = data++;

			int stackSum = 0;
			foreach (var value in stackSpan)
				stackSum += value;

			Console.WriteLine($"The sum is {stackSum}");
			// Output:  The sum is 4950
		}

		public void Test4()
		{
			int length = 3;
			Span<int> numbers = stackalloc int[length];
			for (var i = 0; i < length; i++)
			{
				numbers[i] = i;
			}
		}
		#region Test 5
		public static void WorkWithSpans()
		{
			// Create a span over an array.
			var array = new byte[100];
			var arraySpan = new Span<byte>(array);

			InitializeSpan(arraySpan);
			Console.WriteLine($"The sum is {ComputeSum(arraySpan):N0}");

			// Create an array from native memory.
			var native = Marshal.AllocHGlobal(100);
			Span<byte> nativeSpan;
			unsafe
			{
				nativeSpan = new Span<byte>(native.ToPointer(), 100);
			}

			InitializeSpan(nativeSpan);
			Console.WriteLine($"The sum is {ComputeSum(nativeSpan):N0}");

			Marshal.FreeHGlobal(native);

			// Create a span on the stack.
			Span<byte> stackSpan = stackalloc byte[100];

			InitializeSpan(stackSpan);
			Console.WriteLine($"The sum is {ComputeSum(stackSpan):N0}");
		}

		public static void InitializeSpan(Span<byte> span)
		{
			byte value = 0;
			for (int ctr = 0; ctr < span.Length; ctr++)
				span[ctr] = value++;
		}

		public static int ComputeSum(Span<byte> span)
		{
			int sum = 0;
			foreach (var value in span)
				sum += value;

			return sum;
		}
		// The example displays the following output:
		//    The sum is 4,950
		//    The sum is 4,950
		//    The sum is 4,950
		#endregion

		#region Test 6
		static void MainX()
		{
			string contentLength = "Content-Length: 132";
			var length = GetContentLength(contentLength.ToCharArray());
			Console.WriteLine($"Content length: {length}");
		}

		private static int GetContentLength(ReadOnlySpan<char> span)
		{
			List<string> names = new List<string>() { "10", "2", "3" };
			names.Sort();
			var slice = span.Slice(16);
			return int.Parse(slice);
		}
		#endregion
	}
}