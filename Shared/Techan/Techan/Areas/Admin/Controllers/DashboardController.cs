using Microsoft.AspNetCore.Mvc;

namespace Techan.Areas.Admin.Controllers;

public class DashboardController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
