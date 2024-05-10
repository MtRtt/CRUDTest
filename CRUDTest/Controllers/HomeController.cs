using Microsoft.AspNetCore.Mvc;

namespace CRUDTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
