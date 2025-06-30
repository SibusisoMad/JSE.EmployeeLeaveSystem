using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSE.EmployeeLeaveSystem.Mvc.Models
{
    public class LeaveRequestPostDto
    {
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
    }
}