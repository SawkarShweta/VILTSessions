using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIForthUserService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private static readonly string[] Departments = new[]
        {
            "HR", "Sales", "IT", "Electronics", "BPO", "Marketing", "Designing", "Networking", "Accounting"
        };

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDepartmentList")]
        public IEnumerable<Department> GetEmployees()
        {
            return Enumerable.Range(1, 5).Select(index => new Department
            {
                Id = index,
                Name = Departments[Random.Shared.Next(Departments.Length)]
            })
            .ToArray();
        }
    }
}
