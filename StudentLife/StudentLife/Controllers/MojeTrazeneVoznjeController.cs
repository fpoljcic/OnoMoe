using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace StudentLife.Controllers
{
    public class MojeTrazeneVoznjeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            return View("mojeTrazeneVoznje");
        }
    }
}