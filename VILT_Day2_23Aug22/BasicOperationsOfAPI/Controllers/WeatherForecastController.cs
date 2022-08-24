using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BasicOperationsOfAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public static List<Employee> emp = new List<Employee>();

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return emp;
        }

        [HttpPost]
        public IActionResult Post(int id,string Ename)
        {
            emp.Add(new Employee{
                EmployeeId=id,
                EmployeeName=Ename
            });

            return Ok();
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult Post([FromBody]Employee e)
        {
            emp.Add(e);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, string Ename)
        {
            try
            {
                if(emp.Contains(emp.Find(emp => emp.EmployeeId == id)))
                {
                    emp.Find(emp => emp.EmployeeId == id).EmployeeName = Ename;
                    return Ok();
                }
                else
                {
                    return BadRequest("Employee with ID " + id + " not found");
                }
            }
            catch(Exception e)
            {
                return BadRequest("Id not found");
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            emp.Remove(emp.Find(emp => emp.EmployeeId == id));
            return Ok();
        }

        #region
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
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