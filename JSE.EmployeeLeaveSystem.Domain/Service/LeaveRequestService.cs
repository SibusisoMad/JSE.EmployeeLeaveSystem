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

        public async Task<List<LeaveRequest>> GetEmployeeLeaveAsync(int employeeId)
        {
            var entities = await _repository.GetEmployeeLeaveAsync(employeeId);

            var result = entities.Select(lr => new LeaveRequest
            {
                Id = lr.Id,
                EmployeeId = lr.EmployeeId,
                EmployeeName = lr.EmployeeName,
                Team = lr.Team,
                LeaveTypeId = lr.LeaveTypeId,
                LeaveTypeName = lr.LeaveTypeName,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                Reason = lr.Reason,
                Status = lr.Status,
                CreatedAt = lr.CreatedAt,
                UpdatedAt = lr.UpdatedAt,
                ActionedById = lr.ActionedById,
                ActionedByName = lr.ActionedByName,
                DateActioned = lr.DateActioned,
                DateRequested = lr.DateRequested ?? DateTime.Now,
                Comments = lr.Comments
            }).ToList();

            return result;
        }


        public Task<List<LeaveRequest>> GetManagerSubordinateLeaveAsync(int managerId)
            => _repository.GetManagerSubordinateLeaveAsync(managerId);

        public Task EditLeaveRequestAsync(LeaveRequest leaveRequest)
            => _repository.EditLeaveRequestAsync(leaveRequest);

        public Task<LeaveRequest?> GetByIdAsync(int leaveRequestId)
            => _repository.GetByIdAsync(leaveRequestId);
    }
}