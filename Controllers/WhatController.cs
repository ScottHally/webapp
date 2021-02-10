using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class WhatController : Controller
    {
        public IActionResult What()
        {
            return View();
        }

        public string Welcome()
        {
            return "Welcome, children!";
        }
    }
}
