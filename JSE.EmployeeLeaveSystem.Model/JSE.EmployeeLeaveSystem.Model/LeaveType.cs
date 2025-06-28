namespace JSE.EmployeeLeaveSystem.Model
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}
