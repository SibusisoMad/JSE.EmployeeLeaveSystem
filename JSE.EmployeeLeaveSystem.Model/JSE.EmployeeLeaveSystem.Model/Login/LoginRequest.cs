using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSE.EmployeeLeaveSystem.Model.Login
{
    public class LoginRequest
    {
        
        public int EmployeeId { get; set; }
        public string Role { get; set; } = "Manager";
    }
}
