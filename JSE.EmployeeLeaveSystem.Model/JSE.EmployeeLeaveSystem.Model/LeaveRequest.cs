using JSE.EmployeeLeaveSystem.Model.Enum;

namespace JSE.EmployeeLeaveSystem.Model
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Requester { get; set; }

        public int LeaveTypeId { get; set; }
        public LeaveType? LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
        public LeaveStatus Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Employee? ActionedBy { get; set; }
        public int ? ActionedById { get; set; }
        public DateTime? DateActioned { get; set; }
        public DateTime? DateRequested { get; set; }
        public string? Comments { get; set; }
    }
}
