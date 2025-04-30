using Microsoft.AspNetCore.Mvc;

namespace EdgecutTemplate.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
