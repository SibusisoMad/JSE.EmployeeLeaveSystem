using JSE.EmployeeLeaveSystem.Dal.Interface;
using JSE.EmployeeLeaveSystem.Domain.Interface;
using JSE.EmployeeLeaveSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSE.EmployeeLeaveSystem.Domain.Service
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _repository;

        public LeaveRequestService(ILeaveRequestRepository repository)
        {
            _repository = repository;
        }

        public Task RequestLeaveAsync(int employeeId, int leaveTypeId, DateTime startDate, DateTime endDate, string reason)
            => _repository.RequestLeaveAsync(employeeId, leaveTypeId, startDate, endDate, reason);

        public Task ApproveLeaveAsync(int leaveRequestId, int managerId, string comments)
            => _repository.ApproveLeaveAsync(leaveRequestId, managerId, comments);

        public Task RejectLeaveAsync(int leaveRequestId, int managerId, string comments)
            => _repository.RejectLeaveAsync(leaveRequestId, managerId, comments);

        public Task RetractLeaveAsync(int leaveRequestId, int employeeId)
            => _repository.RetractLeaveAsync(leaveRequestId, employeeId);

        public Task<List<LeaveRequest>> GetEmployeeLeaveAsync(int employeeId)
            => _repository.GetEmployeeLeaveAsync(employeeId);

        public Task<List<LeaveRequest>> GetManagerSubordinateLeaveAsync(int managerId)
            => _repository.GetManagerSubordinateLeaveAsync(managerId);

        public Task EditLeaveRequestAsync(LeaveRequest leaveRequest)
            => _repository.EditLeaveRequestAsync(leaveRequest);

        public Task<LeaveRequest?> GetByIdAsync(int leaveRequestId)
            => _repository.GetByIdAsync(leaveRequestId);
    }
}