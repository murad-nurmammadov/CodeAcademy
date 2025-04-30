using Microsoft.AspNetCore.Mvc;

namespace JobEntryTemplate.Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
