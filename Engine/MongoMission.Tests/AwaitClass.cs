namespace RetryApp
{
	public class Example
	{
		public static async Task Main_Example()
		{
			try
			{
				var task1 = TaskMethod("Task1");
				var task2 = TaskMethod("Task2");
				string s1 = task1.Result; string s2 = task2.Result;
				Console.WriteLine($"s1 is {s1}");
				Console.WriteLine($"s2 is {s2}");

			}
			catch (Exception ex)
			{

				throw;
			}
		}
		private static async Task<string> TaskMethod(string taskName)
		{
			try
			{
				Console.WriteLine($"{taskName}: AsyncLocal Value =  (first - TaskMethod)");
				//await InnerTaskMethod(taskName);
				Console.WriteLine($"{taskName}: AsyncLocal Value =  (second - TaskMethod)");
				return "task method completed!";
			}
			catch (Exception ex)
			{

				throw;
			}

		}

		private static async Task InnerTaskMethod(string taskName)
		{
			try
			{
				Console.WriteLine($"{taskName}: AsyncLocal Value = (first - InnerTaskMethod)");
				await Task.Delay(1000);
				Console.WriteLine($"{taskName}: AsyncLocal Value = (second - InnerTaskMethod)");
			}
			catch (Exception ex)
			{

				throw;
			}

		}
	}

}
