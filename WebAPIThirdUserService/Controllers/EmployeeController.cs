using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIThirdUserService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "Pratik", "Srushti", "Trupti", "Avinash", "Sushama", "Poonam", "Aarti", "Mitansh"
        };

        private static readonly string[] Departments = new[]
        {
            "HR", "Sales", "IT", "Electronics", "BPO", "Marketing", "Designing", "Networking", "Accounting"
        };

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEmployeeList")]
        public IEnumerable<Employee> GetEmployees()
        {
            return Enumerable.Range(1, 5).Select(index => new Employee
            {
                Id = index,
                Name = Names[Random.Shared.Next(Names.Length)],
                DepartmentName = Departments[Random.Shared.Next(Departments.Length)]
            })
            .ToArray();
        }
    }
}
