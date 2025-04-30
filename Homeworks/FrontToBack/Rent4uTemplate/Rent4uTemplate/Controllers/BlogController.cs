using Microsoft.AspNetCore.Mvc;

namespace Rent4uTemplate.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
