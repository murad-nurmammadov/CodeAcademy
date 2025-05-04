using Microsoft.AspNetCore.Mvc;
using Techan.Models;

namespace Techan.Areas.Admin.Controllers;

[Area("Admin")]
public class BrandController : Controller
{
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Slider slider)
    {
        return View();
    }
}
