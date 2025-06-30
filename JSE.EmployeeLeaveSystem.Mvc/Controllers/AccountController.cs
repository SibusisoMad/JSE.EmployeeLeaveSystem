using JSE.EmployeeLeaveSystem.Mvc.Helpers;
using JSE.EmployeeLeaveSystem.Mvc.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JSE.EmployeeLeaveSystem.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiService _api = new ApiService();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var result = await _api.PostAsync<LoginResponse>("auth/login", model);

                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    // ✅ Store session values
                    Session["JwtToken"] = result.Token;
                    Session["EmployeeId"] = result.EmployeeId; // Should be > 0
                    Session["EmployeeRole"] = result.Role;

                    return RedirectToAction("MyRequests", "Employee");
                }

                ModelState.AddModelError("", "Invalid login credentials.");
                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "Login failed. Please check API or try again later.");
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
