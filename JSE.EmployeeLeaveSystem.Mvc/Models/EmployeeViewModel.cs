using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSE.EmployeeLeaveSystem.Mvc.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public string Role { get; set; }
        public string Team { get; set; }
        public bool IsTeamLead { get; set; }
        public bool IsCEO { get; set; }
        public int ManagerId { get; set; }
    }
}