using Microsoft.AspNetCore.Mvc;

namespace JobEntryTemplate.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
