using Microsoft.AspNetCore.Mvc;

namespace SandeepThippareddy.Controllers
{
    public class PersonalBlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
