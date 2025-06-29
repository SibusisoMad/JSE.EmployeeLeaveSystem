using JSE.EmployeeLeaveSystem.Model;

namespace JSE.EmployeeLeaveSystem.Dal.Interface
{
    public interface ILeaveRequestRepository
    {

        Task RequestLeaveAsync(int employeeId, int leaveTypeId, DateTime startDate, DateTime endDate, string reason);
        Task ApproveLeaveAsync(int leaveRequestId, int managerId, string comments);
        Task RejectLeaveAsync(int leaveRequestId, int managerId, string comments);
        Task RetractLeaveAsync(int leaveRequestId, int employeeId);
        Task<List<LeaveRequest>> GetEmployeeLeaveAsync(int employeeId);
        Task<List<LeaveRequest>> GetManagerSubordinateLeaveAsync(int managerId);
        Task<LeaveRequest?> GetByIdAsync(int leaveRequestId);
        Task EditLeaveRequestAsync(LeaveRequest leaveRequest);
    }
}
