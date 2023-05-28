namespace RetryApp
{
	public class Example
	{
		// Create an AsyncLocal instance with a string type
		private static AsyncLocal<string> asyncLocalValue = new AsyncLocal<string>();
		public static async Task Main_Example()
		{
			try
			{
				// Set the initial value of the AsyncLocal
				asyncLocalValue.Value = "Initial Value";
				Console.WriteLine($"Main: (start) AsyncLocal Value = {asyncLocalValue.Value}");
				// Start two asynchronous tasks (impl 6)
				var task1 = TaskMethod("Task1");
				var task2 = TaskMethod("Task2");
				string s1 = await task1; string s2 = await task2;
				Console.WriteLine($"s1 is {s1}");
				Console.WriteLine($"s2 is {s2}");
				Console.WriteLine($"Main: (end) AsyncLocal Value = {asyncLocalValue.Value}");
				
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
				// Modify the AsyncLocal value in the task
				asyncLocalValue.Value = $"{taskName} Value";
				Console.WriteLine($"{taskName}: AsyncLocal Value = {asyncLocalValue.Value} (first - TaskMethod)");
				await InnerTaskMethod(taskName);
				Console.WriteLine($"{taskName}: AsyncLocal Value = {asyncLocalValue.Value}  (second - TaskMethod)");
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
				Console.WriteLine($"{taskName}: AsyncLocal Value = {asyncLocalValue.Value} (first - InnerTaskMethod)");
				await Task.Delay(1000);
				Console.WriteLine($"{taskName}: AsyncLocal Value = {asyncLocalValue.Value} (second - InnerTaskMethod)");
			}
			catch (Exception ex)
			{

				throw;
			}
			
		}
	}
}