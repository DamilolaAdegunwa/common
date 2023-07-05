//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ExerciseApp.ConsoleApp.Services
//{

//	class Program
//	{
//		static async Task Main(string[] args)
//		{
//			await Host.CreateDefaultBuilder(args)
//				.ConfigureLogging(logging =>
//				{
//					logging.ClearProviders();
//					logging.AddConsole();
//				})
//				.ConfigureServices((hostContext, services) =>
//				{
//					// Configure services
//					services.AddTransient<IMyService, MyService>();
//				})
//				.RunConsoleAsync();
//		}
//	}

//	interface IMyService
//	{
//		Task DoSomethingAsync();
//	}

//	class MyService : IMyService
//	{
//		public Task DoSomethingAsync()
//		{
//			Console.WriteLine("MyService is doing something.");
//			return Task.CompletedTask;
//		}
//	}

//}
