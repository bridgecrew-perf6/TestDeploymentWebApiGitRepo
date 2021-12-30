using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeploymentWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "New Weather", "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            List<WeatherForecast> weatherList = new List<WeatherForecast>();
            for(int i=0; i<5; i++)
            {
                var weather = new WeatherForecast();
                weather.Date = DateTime.Now;
                weather.TemperatureC = rng.Next(-20, 55);
                weather.Summary = Summaries[i];
                weatherList.Add(weather);
            }
            return weatherList;
        }
    }
}
