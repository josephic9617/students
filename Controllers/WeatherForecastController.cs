using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace welcome_api.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserRepo userRepo)
        {
            _userRepo = userRepo;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-5, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{ady}")]
        public IActionResult Name([FromRoute] string ady)
        {
            int userid = _userRepo.GetCurrentUserid();
            if (userid == 8)
            {
                _logger.IsEnabled(LogLevel.Warning);
            }
            return Ok($"Salam, {_userRepo.GetUserById(userid)}, {ady}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast forecast)
        {
            return Ok(forecast.Summary);
        }
    }

}
