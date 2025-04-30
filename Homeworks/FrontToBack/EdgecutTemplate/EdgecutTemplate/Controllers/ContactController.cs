using Microsoft.AspNetCore.Mvc;

namespace EdgecutTemplate.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
