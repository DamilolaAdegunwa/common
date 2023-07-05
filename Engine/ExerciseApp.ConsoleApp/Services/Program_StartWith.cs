using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace ExerciseApp.ConsoleApp.Services
{
    internal class Program_196a7832c8a647a9ab08d1b8cdb3ab7f
    {
        static void Main_196a7832c8a647a9ab08d1b8cdb3ab7f()
        {
            var host2 = WebHost.StartWith(app =>
            {
                #region added
                // Create a new route builder
                var routeBuilder = new RouteBuilder(app);

                // Configure the routes using an action
                ConfigureRoutes(routeBuilder);

                // Build the route handler
                var routes = routeBuilder.Build();

                // Use the routes in the app
                app.UseRouter(routes);

                // Configure the middleware pipeline
                app.UseRouting();

                // Configure the endpoints
                app.UseEndpoints(endpoints =>
                {
                    // Define a simple route
                    endpoints.MapGet("/api", async context =>
                    {
                        //priority over app.run
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
                    await context.Response.WriteAsync("Hello, people of the World!"); // Send "Hello, World!" as the response
                });
                #endregion

                app.UseMiddleware<LoggingMiddleware>();
                app.UseMiddleware<GreetingMiddleware>();
            });
            var host = WebHost.Start("http://localhost:7070", routeBuilder =>
            {
                ConfigureRoutes(routeBuilder);
            });
            Console.ReadLine();
        }
        static void ConfigureRoutes(IRouteBuilder builder)
        {
            // Define a simple route
            builder.MapGet("/", context =>
            {
                return context.Response.WriteAsync("Hello, (Define a simple route)!");
            });

            builder.MapGet("/hello", context =>
            {
                return context.Response.WriteAsync("Hello, boys!");
            });

            builder.MapGet("/asset", context =>
            {
                return context.Response.WriteAsync("Hello, Asset!");
            });

            builder.MapGet("/business", context =>
            {
                return context.Response.WriteAsync("Hello, Business!");
            });

            builder.MapGet("/covid", context =>
            {
                return context.Response.WriteAsync("Hello, Covid!");
            });
        }
    }
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"Request URL: {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

    public class GreetingMiddleware
    {
        private readonly RequestDelegate _next;

        public GreetingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the request path is "/greet"
            if (context.Request.Path == "/greet")
            {
                await context.Response.WriteAsync("Hello, World!");
            }
            else
            {
                // Call the next middleware in the pipeline
                await _next(context);
            }
        }
    }
}