using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExerciseApp.ConsoleApp.Services
{
    class Program_d8122833a40346d39b95908b7977a82d
    {
        static void Main_d8122833a40346d39b95908b7977a82d(string[] args)
        {
            // Create a new web host builder
            var hostBuilder = new WebHostBuilder();

            // Configure the web host
            hostBuilder.ConfigureServices(services =>
            {
                services.AddRouting();
                // Add services to the container
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            });

            // Start the web host and configure the routes
            hostBuilder.UseKestrel();
            hostBuilder.UseStartup<Startup>();
            hostBuilder.Build().Start();
            Console.ReadLine();
        }
    }
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Configure the middleware pipeline
            app.UseRouting();

            // Configure the endpoints
            app.UseEndpoints(endpoints =>
            {
                // Define a simple route
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello, Endpoints!");
                });

                endpoints.MapGet("/me", async context =>
                {
                    await context.Response.WriteAsync("Hello, Oluwadamilola Adegunwa!");
                });

                endpoints.MapPost("/you", async context =>
                {
                    await context.Response.WriteAsync("Hello, Everybody in the room!");
                });
            });

            //app.Run();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello, World!"); // Send "Hello, World!" as the response
            });
        }
    }
}
