using JSE.EmployeeLeaveSystem.Data.Data;
using JSE.EmployeeLeaveSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JSE.EmployeeLeaveSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly LeaveSystemContext _context;

        public LeaveTypesController(LeaveSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveType>>> Get()
        {
            var leaveTypes = await _context.LeaveTypes.ToListAsync();
            return Ok(leaveTypes);
        }
    }
}
