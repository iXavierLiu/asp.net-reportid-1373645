﻿using Microsoft.AspNetCore.Mvc;

namespace Report.Controllers
{
    public class BlogController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
