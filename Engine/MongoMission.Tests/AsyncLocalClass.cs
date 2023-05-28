using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MongoMission.Tests
{
	internal class AsyncLocalClass
	{
	}

	public class Example
	{
		// Create an AsyncLocal instance with a string type
		private static AsyncLocal<string> asyncLocalValue = new AsyncLocal<string>();

		public static async Task Main_Example()
		{
			// Set the initial value of the AsyncLocal
			asyncLocalValue.Value = "Initial Value";

			Console.WriteLine($"Main: AsyncLocal Value = {asyncLocalValue.Value}");

			// Start two asynchronous tasks
			var task1 = Task.Run(() => TaskMethod("Task1"));
			var task2 = Task.Run(() => TaskMethod("Task2"));

			await Task.WhenAll(task1, task2);

			Console.WriteLine($"Main: AsyncLocal Value = {asyncLocalValue.Value}");
		}

		private static async Task TaskMethod(string taskName)
		{
			// Modify the AsyncLocal value in the task
			asyncLocalValue.Value = $"{taskName} Value";

			Console.WriteLine($"{taskName}: AsyncLocal Value = {asyncLocalValue.Value}");

			await InnerTaskMethod(taskName);

			Console.WriteLine($"{taskName}: AsyncLocal Value = {asyncLocalValue.Value}");
		}

		private static async Task InnerTaskMethod(string taskName)
		{
			Console.WriteLine($"{taskName}: AsyncLocal Value = {asyncLocalValue.Value}");

			await Task.Delay(100);

			Console.WriteLine($"{taskName}: AsyncLocal Value = {asyncLocalValue.Value}");
		}
	}

}
