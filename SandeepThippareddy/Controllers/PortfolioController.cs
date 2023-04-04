using Microsoft.AspNetCore.Mvc;

namespace SandeepThippareddy.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
