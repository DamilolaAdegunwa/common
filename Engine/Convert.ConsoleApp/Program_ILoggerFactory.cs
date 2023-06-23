using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertApp.ConsoleApp.Services.Records;
using Microsoft.Extensions.Logging;
namespace ExerciseApp.ConsoleApp
{
	public record struct  testRec
	{
		public int firstNum ; public int secondNum;
	}
	internal unsafe class Program_ILoggerFactory
	{
		
		//static void Main_ILoggerFactory()
		static void Main()
		{
			new TestClass();
			var a = new testRec() { firstNum = 1, secondNum = 2 };
			var b = a with { };
			int c = 4;
            _ = sizeof(int);
			// Create an instance of ILoggerFactory
			ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
			{
				builder.AddConsole(); // Add Console logger provider
				builder.AddDebug(); // Add Debug logger provider
			});

			// Create a logger using the logger factory
			ILogger logger = loggerFactory.CreateLogger<Program_ILoggerFactory>();

			// Log messages using the logger
			logger.LogInformation("Information message");
			logger.LogWarning("Warning message");
			logger.LogError("Error message");

			Console.ReadLine();
		}
	}

	public class TestClass
	{
		public TestClass() {
			unchecked
			{
				int a = 1000000000 + 1000000000 + 1000000000 + 1000000000;
				Console.WriteLine(a); // Output: -1294967296
			}

		}
	}
}
