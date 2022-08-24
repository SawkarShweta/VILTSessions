using Microsoft.AspNetCore.Mvc;

namespace BasicMathApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string Add(int a,int b)
        {
            return "Addition of "+ a +" and "+b+" is "+(a+b).ToString();
        }

        [HttpGet]
        [Route("Substraction")]
        public string Sub(int a, int b)
        {
            return (a - b).ToString();
        }

        [HttpGet]
        [Route("Multiplication")]
        public string Mul(int a, int b)
        {
            return (a + b).ToString();
        }

        [HttpGet]
        [Route("Division")]
        public string Div(int a, int b)
        {
            return (a / b).ToString();
        }

        #region
        //private static readonly string[] Summaries = new[]
        //{
        //"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        #endregion
    }
}