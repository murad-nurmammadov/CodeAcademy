using Microsoft.AspNetCore.Mvc;

namespace JobEntryTemplate.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
