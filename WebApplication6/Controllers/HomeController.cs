using BSLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;


namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Chek()
        {
            return View("Index");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
