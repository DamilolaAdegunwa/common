using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;
using System.Net.Http;
using Steeltoe.Discovery;
using Steeltoe.Discovery.Eureka;
using System;

namespace EurekaDiscoverExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;
        DiscoveryHttpClientHandler _handler;
        public ValuesController(ILogger<ValuesController> logger, IDiscoveryClient client)
        {
            _logger = logger;
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

        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var client = new HttpClient(_handler, false);
            return await client.GetStringAsync("http://EurekaRegisterExample/api/values");
        }
	}
}
