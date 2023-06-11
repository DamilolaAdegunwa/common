using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp
{
	internal class Program_AntiforgeryOptions_Class2
	{
	}

	class Program
	{
		static async Task Main(string[] args)
		{
			var host = Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.ConfigureServices(services =>
					{
						services.AddControllers();

						services.AddAntiforgery(options =>
						{
							options.HeaderName = "X-CSRF-TOKEN";
						});
					});

					webBuilder.Configure(app =>
					{
						app.UseRouting();

						app.UseEndpoints(endpoints =>
						{
							endpoints.MapControllers();
						});
					});
				})
				.Build();

			await host.RunAsync();
		}
	}

	public class ValuesController : ControllerBase
	{
		private readonly IAntiforgery _antiforgery;

		public ValuesController(IAntiforgery antiforgery)
		{
			_antiforgery = antiforgery;
		}

		[HttpGet]
		[Route("api/values")]
		public IActionResult Get()
		{
			// Generate an antiforgery token
			var tokenSet = _antiforgery.GetAndStoreTokens(HttpContext);

			// Set the antiforgery token in the response headers
			Response.Headers.Add("X-CSRF-TOKEN", tokenSet.RequestToken);

			return Ok("API endpoint accessed successfully.");
		}
	}

}
