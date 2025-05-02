using Microsoft.AspNetCore.Mvc;

namespace Techan.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
