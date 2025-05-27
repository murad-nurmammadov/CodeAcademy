using Microsoft.AspNetCore.Mvc;

namespace Techan.Areas.Admin.Controllers;

public class SellersController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
