using JSE.EmployeeLeaveSystem.Dal.Interface;
using JSE.EmployeeLeaveSystem.Data.Data;
using JSE.EmployeeLeaveSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSE.EmployeeLeaveSystem.Dal
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly LeaveSystemContext _context;

        public LeaveRequestRepository(LeaveSystemContext context)
        {
            _context = context;
        }

        public async Task RequestLeaveAsync(int employeeId, int leaveTypeId, DateTime startDate, DateTime endDate, string reason)
            => await _context.RequestLeaveAsync(employeeId, leaveTypeId, startDate, endDate, reason);

        public async Task ApproveLeaveAsync(int leaveRequestId, int managerId, string comments)
            => await _context.ApproveLeaveAsync(leaveRequestId, managerId, comments);

        public async Task RejectLeaveAsync(int leaveRequestId, int managerId, string comments)
            => await _context.RejectLeaveAsync(leaveRequestId, managerId, comments);

        public async Task RetractLeaveAsync(int leaveRequestId, int employeeId)
            => await _context.RetractLeaveAsync(leaveRequestId, employeeId);

        public async Task<List<LeaveRequest>> GetEmployeeLeaveAsync(int employeeId)
            => await _context.GetEmployeeLeaveAsync(employeeId);

        public async Task<List<LeaveRequest>> GetManagerSubordinateLeaveAsync(int managerId)
            => await _context.GetManagerSubordinateLeaveAsync(managerId);

        public async Task<LeaveRequest?> GetByIdAsync(int leaveRequestId)
            => await _context.LeaveRequests.FirstOrDefaultAsync(lr => lr.Id == leaveRequestId);

        public async Task EditLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            await _context.SaveChangesAsync();
        }
    }
}