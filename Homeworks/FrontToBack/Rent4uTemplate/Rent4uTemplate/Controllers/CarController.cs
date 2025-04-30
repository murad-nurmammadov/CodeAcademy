using Microsoft.AspNetCore.Mvc;

namespace Rent4uTemplate.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
