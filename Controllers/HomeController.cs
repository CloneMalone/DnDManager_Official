using Microsoft.AspNetCore.Mvc;

namespace DnDManager.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/About
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }
    }
}
