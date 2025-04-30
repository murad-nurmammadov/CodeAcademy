using Microsoft.AspNetCore.Mvc;

namespace JobEntryTemplate.Controllers
{
    public class JobDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
