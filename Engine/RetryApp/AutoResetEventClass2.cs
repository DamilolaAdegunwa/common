using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;
using System;
using System.Threading;
namespace RetryApp
{
	public class Program_AutoResetEventClass2
	{
		private static AutoResetEvent _event = new AutoResetEvent(false);
		private static int _sharedData = 0;

		public static void Main_AutoResetEventClass2()
		{
			Thread writerThread = new Thread(Writer);
			Thread readerThread = new Thread(Reader);

			writerThread.Start();
			readerThread.Start();

			// Wait for both threads to complete
			writerThread.Join();
			readerThread.Join();

			Console.WriteLine("Program completed.");
		}

		private static void Writer()
		{
			Console.WriteLine("Writer thread is writing data.");

			for (int i = 1; i <= 5; i++)
			{
				// Write the data
				_sharedData = i;

				// Signal the event to notify the reader thread
				_event.Set();

				// Wait for the reader thread to process the data
				_event.WaitOne();
			}
		}

		private static void Reader()
		{
			Console.WriteLine("Reader thread is waiting for data.");

			for (int i = 1; i <= 5; i++)
			{
				// Wait for the writer thread to write data
				_event.WaitOne();

				// Read and process the data
				Console.WriteLine($"Reader thread received data: {_sharedData}");

				// Signal the event to allow the writer thread to continue
				_event.Set();
			}
		}
	}

	//internal class AutoResetEventClass2
	//{
	//}
}
