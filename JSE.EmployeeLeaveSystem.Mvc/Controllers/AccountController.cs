using JSE.EmployeeLeaveSystem.Mvc.Helpers;
using JSE.EmployeeLeaveSystem.Mvc.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JSE.EmployeeLeaveSystem.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiService _api = new ApiService();

        public ActionResult Login() => View();

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            
            var result = await _api.PostAsync<LoginResponse>("auth/login", model);

            if (result != null && !string.IsNullOrEmpty(result.Token))
            {
                Session["JwtToken"] = result.Token;
                Session["EmployeeId"] = result.EmployeeId;
                Session["EmployeeRole"] = result.Role;

                return RedirectToAction("MyRequests", "Employee");
            }

            ModelState.AddModelError("", "Invalid login.");
            return View(model);
        }


        public ActionResult Logout()
        {
            Session["JwtToken"] = null;
            return RedirectToAction("Login");
        }
    }
}