﻿using Microsoft.AspNetCore.Mvc;

namespace Techan.Areas.Admin.Controllers;

public class OrdersController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
