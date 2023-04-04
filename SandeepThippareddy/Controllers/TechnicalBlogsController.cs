using Microsoft.AspNetCore.Mvc;

namespace SandeepThippareddy.Controllers
{
    public class TechnicalBlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
