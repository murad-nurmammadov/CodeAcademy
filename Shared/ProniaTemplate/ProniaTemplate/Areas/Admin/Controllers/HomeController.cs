using Microsoft.AspNetCore.Mvc;

namespace ProniaTemplate.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
