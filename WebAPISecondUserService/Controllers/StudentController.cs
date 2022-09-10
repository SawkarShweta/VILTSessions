using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPISecondUserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class StudentController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "Shweta", "Pooja", "Swati", "Pravin", "Milind", "Tushar", "Rohan", "Rohit", "Saloni", "priti"
        };

        private static readonly string[] Addresses = new[]
        {
        "Pune", "Mumbai", "Delhi", "Chennai", "Hyderabad", "Kolkata", "Manali", "Bangalore", "Mysore", "Jaipur"
        };

        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStudentList")]
        public IEnumerable<Student> GetStudents()
        {
            return Enumerable.Range(1, 5).Select(index => new Student
            {
                Id= index,
                Name = Names[Random.Shared.Next(Names.Length)],
                Address=Addresses[Random.Shared.Next(Addresses.Length)]
            })
            .ToArray();
        }
    }
}