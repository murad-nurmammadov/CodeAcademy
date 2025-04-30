using Microsoft.AspNetCore.Mvc;

namespace EdgecutTemplate.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
