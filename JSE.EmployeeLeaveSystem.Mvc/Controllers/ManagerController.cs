using JSE.EmployeeLeaveSystem.Mvc.Helpers;
using JSE.EmployeeLeaveSystem.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JSE.EmployeeLeaveSystem.Mvc.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApiService _api = new ApiService();

        public async Task<ActionResult> SubordinateRequests()
        {
            var token = Session["JwtToken"] as string;
            var requests = await _api.GetAsync<List<LeaveRequestViewModel>>("LeaveRequests/subordinates", token);
            return View(requests);
        }

        [HttpPost]
        public async Task<ActionResult> Approve(int id, string comments)
        {
            var token = Session["JwtToken"] as string;
            await _api.PostAsync<object>($"LeaveRequests/{id}/approve", comments, token);
            return RedirectToAction("SubordinateRequests");
        }

        [HttpPost]
        public async Task<ActionResult> Reject(int id, string comments)
        {
            var token = Session["JwtToken"] as string;
            await _api.PostAsync<object>($"LeaveRequests/{id}/reject", comments, token);
            return RedirectToAction("SubordinateRequests");
        }
    }
}