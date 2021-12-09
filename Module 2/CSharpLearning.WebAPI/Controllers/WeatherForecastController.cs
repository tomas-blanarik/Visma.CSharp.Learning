using CSharpLearning.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLearning.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpPost("account")]
        public IActionResult CreateAccount(Account account)
        {
            return Ok(account);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            List<WeatherForecast> forecasts = null;
            try
            {
                forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 400
                // 500
            }

            if (forecasts.Count == 0)
            {
                return NoContent(); // 204
            }

            return Ok(forecasts); // 200
        }
    }
}
