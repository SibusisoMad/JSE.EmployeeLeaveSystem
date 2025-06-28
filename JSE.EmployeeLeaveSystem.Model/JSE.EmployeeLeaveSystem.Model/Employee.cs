using JSE.EmployeeLeaveSystem.Model.Enum;

namespace JSE.EmployeeLeaveSystem.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? CellNumber { get; set; }

        public EmployeeRole Role { get; set; }

        public Team Team { get; set; }

        public bool  IsTeamLead { get; set; }

        public bool IsCEO { get; set; }
        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }

        public  ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

    }
}
