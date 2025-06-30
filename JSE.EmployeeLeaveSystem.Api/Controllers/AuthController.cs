using JSE.EmployeeLeaveSystem.Data.Data;
using JSE.EmployeeLeaveSystem.Model.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JSE.EmployeeLeaveSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly LeaveSystemContext _context;

        public AuthController(IConfiguration config, LeaveSystemContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.EmployeeNumber))
                return BadRequest("Email and Employee Number are required.");

            var employee = _context.Employees
                .FirstOrDefault(e => e.Email == request.Email && e.EmployeeNumber == request.EmployeeNumber);

            if (employee == null)
                return Unauthorized("Invalid credentials");

            var token = GenerateJwtToken(employee.Id, employee.Role.ToString());

            return Ok(new LoginResponse
            {
                Token = token,
                EmployeeId = employee.Id,
                Role = employee.Role.ToString()
            });
        }

        private string GenerateJwtToken(int employeeId, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim("EmployeeId", employeeId.ToString()), 
        new Claim("Role", role)
    };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
