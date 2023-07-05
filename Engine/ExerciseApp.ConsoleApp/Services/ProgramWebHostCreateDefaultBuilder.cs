using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Engines;
using Microsoft.AspNetCore;

namespace ExerciseApp.ConsoleApp
{
	class Program_e5bb2e031a354a429e4113758eb64061
	{
		static async Task Main_e5bb2e031a354a429e4113758eb64061(string[] args)
		{
			var host = CreateWebHostBuilder(args);
			host.Build().Run();
			//var host = Host.CreateDefaultBuilder(args)
			//.ConfigureWebHostDefaults(webBuilder =>
			//	{
			//		webBuilder.Configure(app =>
			//		{
			//			app.Run(async (context) =>
			//			{
			//				await context.Response.WriteAsync("Hello, World!"); // Send "Hello, World!" as the response
			//			});
			//		});
			//	})
			//	.Build();
			//await host.RunAsync(); // Start the application host
		}
		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
		WebHost.CreateDefaultBuilder(args)
			.UseKestrel() // Use Kestrel as the web server
			.UseStartup<Startup>();

		//parody
		//public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		//{
		//	return WebHost.Start(default).Run();
		//}
	}
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello, World!"); // Send "Hello, World!" as the response
			});
		}
	}
}