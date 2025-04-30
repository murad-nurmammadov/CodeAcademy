using Microsoft.AspNetCore.Mvc;

namespace JobEntryTemplate.Controllers
{
    public class JobListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
