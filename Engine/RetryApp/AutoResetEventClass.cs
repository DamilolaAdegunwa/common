using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace RetryApp
{
	public class Program_AutoResetEvent
	{
		private static AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
		private static bool _completed = false;

		public static void Main_AutoResetEvent()
		{
			Thread workerThread = new Thread(DoWork);
			workerThread.Start();

			Console.WriteLine("Main thread is doing some work...");

			// Simulate some work in the main thread
			Thread.Sleep(2000);

			// Signal the AutoResetEvent to allow the worker thread to proceed
			Console.WriteLine("Signaling the AutoResetEvent...");
			_autoResetEvent.Set();

			// Wait for the worker thread to complete its work
			_autoResetEvent.WaitOne();

			// Continue with the main thread's execution
			Console.WriteLine("Main thread resumed.");

			// Additional work in the main thread
			Thread.Sleep(2000);

			// Signal completion to the worker thread
			_completed = true;
			_autoResetEvent.Set();

			// Wait for the worker thread to exit
			workerThread.Join();

			Console.WriteLine("Program completed.");
		}

		private static void DoWork()
		{
			Console.WriteLine("Worker thread is waiting for a signal...");

			// Wait for the AutoResetEvent to be signaled
			_autoResetEvent.WaitOne();

			Console.WriteLine("Worker thread resumed. Performing work...");

			// Simulate some work in the worker thread
			Thread.Sleep(3000);

			// Signal the AutoResetEvent to indicate completion
			if (_completed)
				Console.WriteLine("Worker thread completed its work.");
			else
				Console.WriteLine("Worker thread aborted.");

			_autoResetEvent.Set();
		}
	}

	//internal class AutoResetEventClass
	//{
	//}
}
