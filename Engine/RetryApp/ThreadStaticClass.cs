using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryApp
{
	public class ThreadStaticClass
	{
		//case 1
		//[ThreadStatic]
		//public static int threadSpecificValue;

		//case 2
		//public static ThreadLocal<int> threadSpecificValue = new ThreadLocal<int>();

		//case 3
		public static AsyncLocal<int> threadSpecificValue = new AsyncLocal<int>();
		public static void Main_ThreadStaticClass()
		{
			// Start two threads
			Thread t1 = new Thread(TestMethod);
			Thread t2 = new Thread(TestMethod);

			t1.Start();
			t2.Start();

			t1.Join();
			t2.Join();

			Console.WriteLine("Thread 1: " + threadSpecificValue.Value); // Prints 0
			Console.WriteLine("Thread 2: " + threadSpecificValue.Value); // Prints 0
		}

		public static void TestMethod()
		{
			Random random = new Random();
			threadSpecificValue.Value = threadSpecificValue.Value== 0 ?  random.Next(int.MinValue, int.MaxValue) : threadSpecificValue.Value;
			//if (Thread.CurrentThread.ManagedThreadId == 1)
			//{
			//	threadSpecificValue = 10;
			//}
			//else
			//{
			//	threadSpecificValue = 20;
			//}
			Console.WriteLine("threadSpecificValue::" + threadSpecificValue.Value);
		}
	}
}
