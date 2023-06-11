using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace ExerciseApp.ConsoleApp
{
	internal class Program_ILoggerFactory
	{
		//static void Main_ILoggerFactory()
		static void Main()
		{
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
}
