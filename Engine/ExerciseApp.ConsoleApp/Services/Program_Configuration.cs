using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Services
{
    internal class Program_Configuration
    {
        static void Main_06e764cc5b1bdef59c27a8()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            if (!File.Exists(dir + $"\\appsettings.json"))
            {
                File.Create(dir + $"\\appsettings.json");
            }
            // Build the configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Access configuration values
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            string apiKey = configuration["APIKey"];
            int maxRetryAttempts = configuration.GetValue<int>("MaxRetryAttempts");

            // Display the values
            Console.WriteLine($"Connection String: {connectionString}");
            Console.WriteLine($"API Key: {apiKey}");
            Console.WriteLine($"Max Retry Attempts: {maxRetryAttempts}");

            Console.ReadLine();
        }
    }
}
