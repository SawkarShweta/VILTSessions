using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public string GetToken()
        {
            string bodyContent = new StreamReader(Request.Body).ReadToEnd();
            return DateTime.Now.ToString();
        }
    }
}
