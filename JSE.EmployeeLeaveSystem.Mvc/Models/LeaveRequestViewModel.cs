using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSE.EmployeeLeaveSystem.Mvc.Models
{
    public class LeaveRequestViewModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please select a leave type.")]
        public int LeaveTypeId { get; set; }

        public string LeaveTypeName { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DataType(DataType.Date)]
        //[CompareDate("StartDate", ErrorMessage = "End date must be on or after start date.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
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