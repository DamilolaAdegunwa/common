using Microsoft.AspNetCore.Mvc;
using MongoMission.Core.Interfaces;
using MongoMission.Core.Models.Collections;
using System.Net.Mime;

namespace MongoMission.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISampleService _sampleService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISampleService sampleService)
        {
            _logger = logger;
            _sampleService = sampleService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var prod = new Product
            {
                Price = 10m,
                ProductCode = "MTN",
                ProductName = "Mobile Telephone Network."
            };
            _sampleService.SaveProduct(prod);
            _sampleService.GetProducts();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}