namespace JSE.EmployeeLeaveSystem.Model.Login
{
    public class LoginRequest
    {
        
        public int EmployeeId { get; set; }
        public string Role { get; set; } = "Employee";
    }
}
