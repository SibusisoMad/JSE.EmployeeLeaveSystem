using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSE.EmployeeLeaveSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
    }
}
