﻿using Microsoft.AspNetCore.Mvc;

namespace DrollTemplate.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
