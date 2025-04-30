using Microsoft.AspNetCore.Mvc;

namespace JobEntryTemplate.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
