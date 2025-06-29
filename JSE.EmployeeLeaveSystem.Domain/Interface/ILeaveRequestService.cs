using JSE.EmployeeLeaveSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSE.EmployeeLeaveSystem.Domain.Interface
{
    public interface ILeaveRequestService
    {

        Task RequestLeaveAsync(int employeeId, int leaveTypeId, DateTime startDate, DateTime endDate, string reason);
        Task ApproveLeaveAsync(int leaveRequestId, int managerId, string comments);
        Task RejectLeaveAsync(int leaveRequestId, int managerId, string comments);
        Task RetractLeaveAsync(int leaveRequestId, int employeeId);
        Task<List<LeaveRequest>> GetEmployeeLeaveAsync(int employeeId);
        Task<List<LeaveRequest>> GetManagerSubordinateLeaveAsync(int managerId);
        Task EditLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest?> GetByIdAsync(int leaveRequestId);
    }
}
