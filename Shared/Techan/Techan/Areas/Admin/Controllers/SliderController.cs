using Microsoft.AspNetCore.Mvc;
using Techan.Models;

namespace Techan.Areas.Admin.Controllers;

public class SliderController : AdminBaseController
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
