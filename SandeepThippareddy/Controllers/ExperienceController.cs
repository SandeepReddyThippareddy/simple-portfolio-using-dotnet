using Microsoft.AspNetCore.Mvc;

namespace SandeepThippareddy.Controllers
{
    public class ExperienceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
