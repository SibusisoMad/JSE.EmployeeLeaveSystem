using JSE.EmployeeLeaveSystem.Api.Authorization;
using JSE.EmployeeLeaveSystem.Domain.Interface;
using JSE.EmployeeLeaveSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSE.EmployeeLeaveSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestsController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpPost]
        public async Task<IActionResult> RequestLeave([FromBody] LeaveRequest request)
        {
            var employeeId = User.GetEmployeeId();
            await _leaveRequestService.RequestLeaveAsync(employeeId, request.LeaveTypeId, request.StartDate, request.EndDate, request.Reason ?? "");
            return Ok();
        }

        [HttpGet("LeaveRequest")]
        public async Task<ActionResult<List<LeaveRequest>>> GetMyLeaveRequests([FromQuery] int? employeeId)
        {
            if (employeeId == null)
                employeeId = User.GetEmployeeId();

            var leaves = await _leaveRequestService.GetEmployeeLeaveAsync(employeeId.Value) ?? new List<LeaveRequest>(); ;
            return Ok(leaves);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditLeaveRequest(int id, [FromBody] LeaveRequest request)
        {
            var employeeId = User.GetEmployeeId();
            var existing = await _leaveRequestService.GetByIdAsync(id);
            if (existing == null || existing.Status != Model.Enum.LeaveStatus.Pending || existing.EmployeeId != employeeId)
                return BadRequest("Only your own pending requests can be edited.");

            existing.StartDate = request.StartDate;
            existing.EndDate = request.EndDate;
            existing.Reason = request.Reason;
            existing.LeaveTypeId = request.LeaveTypeId;
            existing.UpdatedAt = DateTime.UtcNow;

            await _leaveRequestService.EditLeaveRequestAsync(existing);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RetractLeaveRequest(int id)
        {
            var employeeId = User.GetEmployeeId();
            var existing = await _leaveRequestService.GetByIdAsync(id);
            if (existing == null || existing.Status != Model.Enum.LeaveStatus.Pending || existing.EmployeeId != employeeId)
                return BadRequest("Only your own pending requests can be retracted.");

            await _leaveRequestService.RetractLeaveAsync(id, employeeId);
            return Ok();
        }

        [HttpGet("subordinates")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<List<LeaveRequest>>> GetSubordinateLeaveRequests()
        {
            var managerId = User.GetEmployeeId();
            var leaves = await _leaveRequestService.GetManagerSubordinateLeaveAsync(managerId);
            return Ok(leaves);
        }

        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> ApproveLeave(int id, [FromBody] string? comments)
        {
            var managerId = User.GetEmployeeId();
             await _leaveRequestService.ApproveLeaveAsync(id, managerId, comments ?? "");
            return Ok();
        }

        [HttpPost("{id}/reject")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> RejectLeave(int id, [FromBody] string? comments)
        {
            var managerId = User.GetEmployeeId();
            await _leaveRequestService.RejectLeaveAsync(id, managerId, comments ?? "");
            return Ok();
        }
    }
}
