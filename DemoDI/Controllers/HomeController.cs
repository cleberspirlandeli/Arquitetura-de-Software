using Microsoft.AspNetCore.Mvc;

namespace DemoDI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}