using Microsoft.AspNetCore.Mvc;

namespace DrollTemplate.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
