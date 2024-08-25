using Microsoft.AspNetCore.Mvc;

namespace FeedForward.Controllers
{
    public class HomeScreenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
