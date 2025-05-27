using Microsoft.AspNetCore.Mvc;

namespace Techan.Areas.Admin.Controllers;

public class TransactionsController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
