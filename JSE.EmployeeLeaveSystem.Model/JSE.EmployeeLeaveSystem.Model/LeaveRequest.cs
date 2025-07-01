using JSE.EmployeeLeaveSystem.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSE.EmployeeLeaveSystem.Model
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string? Reason { get; set; }

        public LeaveStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int? ActionedById { get; set; }

        public DateTime? DateActioned { get; set; }
        public DateTime? DateRequested { get; set; }

        public string? Comments { get; set; }

       
        public string? EmployeeName { get; set; }

        public string? LeaveTypeName { get; set; }


        public string? ActionedByName { get; set; }

        public string? Team { get; set; }


        [NotMapped]
        public Employee? Requester { get; set; }

        [NotMapped]
        public LeaveType? LeaveType { get; set; }

        [NotMapped]
        public Employee? ActionedBy { get; set; }
    }
}
