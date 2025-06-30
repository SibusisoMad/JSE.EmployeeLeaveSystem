using JSE.EmployeeLeaveSystem.Mvc.Helpers;
using JSE.EmployeeLeaveSystem.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JSE.EmployeeLeaveSystem.Mvc.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApiService _api = new ApiService();

        
        public async Task<ActionResult> SubordinateRequests()
        {
            var token = Session["JwtToken"] as string;
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Account");

            try
            {
                var requests = await _api.GetAsync<List<LeaveRequestViewModel>>("LeaveRequests/subordinates", token);
                return View(requests);
            }
            catch (HttpRequestException)
            {
                ViewBag.Error = "Failed to load leave requests. Please try again.";
                return View(new List<LeaveRequestViewModel>());
            }
        }

        
        [HttpPost]
        public async Task<ActionResult> Approve(int id, string comments)
        {
            var token = Session["JwtToken"] as string;
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Account");

            try
            {
                await _api.PostAsync<object>($"LeaveRequests/{id}/approve", comments ?? "", token);
                return RedirectToAction("SubordinateRequests");
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Error approving leave request.");
                return RedirectToAction("SubordinateRequests");
            }
        }

        
        [HttpPost]
        public async Task<ActionResult> Reject(int id, string comments)
        {
            var token = Session["JwtToken"] as string;
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Account");

            try
            {
                await _api.PostAsync<object>($"LeaveRequests/{id}/reject", comments ?? "", token);
                return RedirectToAction("SubordinateRequests");
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Error rejecting leave request.");
                return RedirectToAction("SubordinateRequests");
            }
        }
    }
}
