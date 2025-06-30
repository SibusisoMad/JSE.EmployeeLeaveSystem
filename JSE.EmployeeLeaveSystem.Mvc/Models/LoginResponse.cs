using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSE.EmployeeLeaveSystem.Mvc.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public int EmployeeId { get; set; }
        public string Role { get; set; }
    }
}