using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;
namespace RetryApp
{
	public static class ThreadExtension
	{
		public static void WaitAll(this IEnumerable<Thread> threads)
		{
			if (threads != null)
			{
				foreach (Thread thread in threads)
				{ thread.Join(); }
			}
		}
	}
	public class Program_AutoResetEventClass3
	{
		private static AutoResetEvent _event = new AutoResetEvent(false);
		private static int _sharedData = 0;
		private static int _threadsCompleted = 0;
		private static ManualResetEvent[] waitHandles = new ManualResetEvent[5];
		public static void Main_AutoResetEventClass3()
		{
			const int NumThreads = 5;
			Thread[] threads = new Thread[NumThreads];

			for (int i = 0; i < NumThreads; i++)
			{
				waitHandles[i] = new ManualResetEvent(false); // Initialize each event as unsignaled
				threads[i] = new Thread(Worker);
				//threads[i].Start(i);
				threads[i].Start(waitHandles[i]);

			}

			// Wait for all threads to complete
			WaitHandle.WaitAll(waitHandles);
			//threads.WaitAll();

			Console.WriteLine("Program completed.");
		}

		private static void Worker(object threadId)
		{
			int id = (int)threadId;
			Console.WriteLine($"Worker thread {id} is starting.");

			for (int i = 1; i <= 5; i++)
			{
				// Wait for the previous thread to signal the event
				_event.WaitOne();

				// Perform some work using the shared data
				Console.WriteLine($"Worker thread {id} received data: {_sharedData}");

				// Modify the shared data
				_sharedData++;

				//// Signal the next thread to proceed
				//if (id < _event.GetAccessControl().GetRule(typeof(Semaphore)).WaitAny(new WaitHandle[] { _event }, 0))
				//{
				//	_event.Set();
				//}

				// Signal the next thread to proceed
				_event.Set();

			}

			// Increment the counter to track completed threads
			Interlocked.Increment(ref _threadsCompleted);

			// If all threads have completed, signal the main thread to exit
			if (_threadsCompleted == 5)
			{
				_event.Set();
			}

			Console.WriteLine($"Worker thread {id} completed.");
		}
	}

	//internal class AutoResetEventClass3
	//{
	//}
}
