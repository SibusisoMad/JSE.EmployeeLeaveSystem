using JSE.EmployeeLeaveSystem.Mvc.Helpers;
using JSE.EmployeeLeaveSystem.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace JSE.EmployeeLeaveSystem.Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApiService _api = new ApiService();

        public async Task<ActionResult> MyRequests()
        {
            var token = Session["JwtToken"] as string;

            if (Session["EmployeeId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var employeeId = (int)Session["EmployeeId"];
            var requests = await _api.GetAsync<List<LeaveRequestViewModel>>($"LeaveRequests/LeaveRequest", token);

            return View(requests);
        }

        public async Task<ActionResult> CreateLeave()
        {
            var token = Session["JwtToken"] as string;
            var leaveTypes = await _api.GetAsync<List<LeaveTypeViewModel>>("LeaveTypes", token);
            ViewBag.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");
            return View();
        }

       
[HttpPost]
public async Task<ActionResult> CreateLeave(LeaveRequestViewModel model)
        {
            var token = Session["JwtToken"] as string;

            if (Session["EmployeeId"] != null)
                model.EmployeeId = (int)Session["EmployeeId"];
            else
            {
                ModelState.AddModelError("", "Session expired. Please log in again.");
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                var leaveTypes = await _api.GetAsync<List<LeaveTypeViewModel>>("LeaveTypes", token);
                ViewBag.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");
                return View(model);
            }

            try
            {
                
                var dto = new LeaveRequestPostDto
                {
                    LeaveTypeId = model.LeaveTypeId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Reason = model.Reason
                     
                };

                await _api.PostAsync<object>("LeaveRequests", dto, token);

                return RedirectToAction("MyRequests");
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(string.Empty, "Unable to submit leave request. Please try again.");
                var leaveTypes = await _api.GetAsync<List<LeaveTypeViewModel>>("LeaveTypes", token);
                ViewBag.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");
                return View(model);
            }
        }
        public async Task<ActionResult> EditLeave(int id)
        {
            var token = Session["JwtToken"] as string;
            var request = await _api.GetAsync<LeaveRequestViewModel>($"LeaveRequests/{id}", token);
            var leaveTypes = await _api.GetAsync<List<LeaveTypeViewModel>>("LeaveTypes", token);
            ViewBag.LeaveTypes = new SelectList(leaveTypes, "Id", "Name", request.LeaveTypeId);
            return View(request);
        }

        [HttpPost]
        public async Task<ActionResult> EditLeave(LeaveRequestViewModel model)
        {
            var token = Session["JwtToken"] as string;
            await _api.PutAsync<object>($"LeaveRequests/{model.Id}", model, token);
            return RedirectToAction("MyRequests");
        }

        public async Task<ActionResult> RetractLeave(int id)
        {
            var token = Session["JwtToken"] as string;
            await _api.DeleteAsync<object>($"LeaveRequests/{id}", token);
            return RedirectToAction("MyRequests");
        }
    }
}
