using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSE.EmployeeLeaveSystem.Mvc.Models
{
    public class LeaveRequestViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ActionedById { get; set; }
        public string ActionedByName { get; set; }
        public DateTime? DateActioned { get; set; }
        public DateTime? DateRequested { get; set; }
        public string Comments { get; set; }
    }
}