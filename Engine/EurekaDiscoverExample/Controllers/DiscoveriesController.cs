using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;
using System.Net.Http;
using Steeltoe.Discovery;
using Steeltoe.Discovery.Eureka;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Diagnostics;
using Newtonsoft.Json;
namespace EurekaDiscoverExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoveriesController : ControllerBase
    {
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILogger<DiscoveriesController> _logger;
		DiscoveryHttpClientHandler _handler;
		public DiscoveriesController(IHttpClientFactory httpClientFactory, ILogger<DiscoveriesController> logger, IDiscoveryClient client)
		{
			_logger = logger;
			_httpClientFactory = httpClientFactory;
			_handler = new DiscoveryHttpClientHandler(client);

			// Get an instance of a service from the discovery client
			var serviceInstance = client.GetLocalServiceInstance();

			// Print the details of the service instance
			Console.WriteLine("Service Instance:");
			Console.WriteLine($"  ServiceId: {serviceInstance.ServiceId}");
			Console.WriteLine($"  Host: {serviceInstance.Host}");
			Console.WriteLine($"  Port: {serviceInstance.Port}");
			Console.WriteLine($"  URI: {serviceInstance.Uri}");
		}

		[HttpGet("weather-object")]
		public async Task<IActionResult> GetWeatherForecast()
		{
			var client = _httpClientFactory.CreateClient(AppConstants.EurekaRegisterExample);
			var weather = await client.GetFromJsonAsync<IList<WeatherForecast>>("api/weatherforecast");
			var weatherJson = JsonConvert.SerializeObject(weather, Formatting.Indented);
			return Ok(weather);
		}

        [HttpGet("weather-string")]
        public async Task<string> Get()
        {
            var client = new HttpClient(_handler, false);
            return await client.GetStringAsync($"{AppConstants.EurekaRegisterBaseUrl}api/WeatherForecast");
        }
	}
}