using Microsoft.AspNetCore.Mvc;

namespace SandeepThippareddy.Controllers
{
    public class ServicesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
