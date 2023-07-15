using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Steeltoe.Discovery;
using System;

namespace EurekaDiscoverExample.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MyController : ControllerBase
	{
		private readonly IDiscoveryClient _discoveryClient;
		private readonly ILogger<MyController> _logger;

		public MyController(IDiscoveryClient discoveryClient, ILogger<MyController> logger)
		{
			_discoveryClient = discoveryClient;
			_logger = logger;
			_logger.LogInformation("here is to doing your work  for too f**king long!");
			_logger.LogDebug("more debugging!");
			_logger.LogTrace($"more logging! {DateTime.Now}");
		}

		[HttpGet]
		public IActionResult Get()
		{
			var services = _discoveryClient.Services; // Retrieve the list of discovered services
			return Ok(services);
		}
	}
}
