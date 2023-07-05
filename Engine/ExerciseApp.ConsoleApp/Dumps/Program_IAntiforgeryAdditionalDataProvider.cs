using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Dumps
{

	class Program_IAntiforgeryAdditionalDataProvider
	{
		static async Task Main_Program_IAntiforgeryAdditionalDataProvider(string[] args)
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
							///options.AdditionalDataProvider = new CustomAntiforgeryAdditionalDataProvider();
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

	public class CustomAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider
	{
		//public Task<AntiforgeryAdditionalData> GetAdditionalData(HttpContext context)
		public Dictionary<string, string> additionalData = new Dictionary<string, string>();
		public string GetAdditionalData(HttpContext context)
		{
			// Simulate retrieving additional data from a custom source
			additionalData = new Dictionary<string, string>
		{
			{ "UserId", "123" },
			{ "SessionId", "ABC123" }
		};
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(additionalData);
			//return Task.FromResult(json);
			return json;
			//return Task.FromResult(new AntiforgeryAdditionalData(additionalData));
		}

		//public Task<bool> ValidateAdditionalData(HttpContext context, AntiforgeryAdditionalData additionalData)
		public bool ValidateAdditionalData(HttpContext context, string _additionalData)
		{
			// Simulate validating the additional data
			var userId = additionalData["UserId"];
			var sessionId = additionalData["SessionId"];

			// Perform validation logic
			bool isValid = !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(sessionId);

			//return Task.FromResult(isValid);
			return isValid;
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
