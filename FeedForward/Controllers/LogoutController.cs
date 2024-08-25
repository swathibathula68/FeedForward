using Microsoft.AspNetCore.Mvc;

namespace FeedForward.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult logout()
        {
            string currUserID = HttpContext.Session.GetString("UserID");
            currUserID = null;
            return RedirectToAction("UserLogin", "UserManagment");
        }
    }
}
