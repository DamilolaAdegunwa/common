using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExerciseApp.ConsoleApp.Services
{

    class Program_1496c834b8f84e9da9978afd7568d140
    {
        static void Main_1496c834b8f84e9da9978afd7568d140(string[] args)
        {
            // Create a new web host builder
            var hostBuilder = new WebHostBuilder();

            // Configure the web host
            hostBuilder.ConfigureServices(services =>
            {
                services.AddRouting();
                services.AddHttpContextAccessor();
                // Add services to the container
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            });

            // Start the web host and configure the routes
            hostBuilder.UseKestrel();
            hostBuilder.UseStartup<Startup>();
            hostBuilder.Start();
            Console.ReadLine();
        }

        public class Startup
        {
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
            public void Configure(IApplicationBuilder app)
            {
                // Create a new route builder
                var routeBuilder = new RouteBuilder(app);

                // Configure the routes using an action
                ConfigureRoutes(routeBuilder);

                // Build the route handler
                var routes = routeBuilder.Build();

                // Use the routes in the app
                app.UseRouter(routes);

                //// Handle a sample request
                //var httpContext = new DefaultHttpContext();

                //// Configure the HttpContext properties
                //httpContext.Request.Method = "GET";
                //httpContext.Request.Path = "/hello";
                //httpContext.Request.Headers["Accept"] = "application/json";
                //httpContext.Response.StatusCode = 200;
                //httpContext.Response.Headers["Content-Type"] = "application/json";
                //httpContext.Response.WriteAsync("{\"message\": \"Hello, World!\"}").GetAwaiter().GetResult();

                ////another section
                //var context = new RouteContext(httpContext);
                //routes.RouteAsync(context).GetAwaiter().GetResult();
                //var handler = context.Handler;

                //// Handle a sample request
                //var context = new RouteContext(httpContext.HttpContext);
                //context.HttpContext.Request.Path = "/hello";
                //routes.RouteAsync(context).GetAwaiter().GetResult();
                //var handler = context.Handler;

                //// Print the result
                //if (handler != null)
                //{
                //	string result = string.Empty;
                //	handler(context.HttpContext).GetAwaiter().GetResult();
                //	Console.WriteLine(result);
                //}

                // Configure the middleware pipeline
                app.UseRouting();

                // Configure the endpoints
                app.UseEndpoints(endpoints =>
                {
                    // Define a simple route
                    endpoints.MapGet("/", async context =>
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
            }
        }
    }

}
