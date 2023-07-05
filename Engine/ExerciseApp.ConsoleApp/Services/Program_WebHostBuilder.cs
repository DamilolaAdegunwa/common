//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//namespace ExerciseApp.ConsoleApp
//{
//	public class Program
//	{
//		public static void Main(string[] args)
//		{
//			var host = new WebHostBuilder()
//				.UseKestrel() // Use Kestrel as the web server
//				.UseStartup<Startup>() // Specify the startup class
//				.Build();

//			host.Run(); // Start the web application
//		}
//	}

//	public class Startup
//	{
//		public void Configure(IApplicationBuilder app)
//		{
//			app.Run(async (context) =>
//			{
//				await context.Response.WriteAsync("Hello, World!"); // Send "Hello, World!" as the response
//			});
//		}
//	}
//}