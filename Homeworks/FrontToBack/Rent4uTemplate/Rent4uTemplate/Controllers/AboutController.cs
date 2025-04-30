using Microsoft.AspNetCore.Mvc;

namespace Rent4uTemplate.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
