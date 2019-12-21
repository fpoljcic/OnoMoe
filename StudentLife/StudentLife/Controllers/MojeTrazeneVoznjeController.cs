using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentLife.Controllers
{
    public class MojeTrazeneVoznjeController : Controller
    {
        public IActionResult Index()
        {
            return View("mojeTrazeneVoznje");
        }
    }
}