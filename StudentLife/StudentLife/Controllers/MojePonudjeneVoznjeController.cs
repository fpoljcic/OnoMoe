using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentLife.Controllers
{
    public class MojePonudjeneVoznjeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            return View("mojePonudjeneVoznje");
        }

        public IActionResult logout()
        {
            return View("../Home/Index");
        }
    }
}