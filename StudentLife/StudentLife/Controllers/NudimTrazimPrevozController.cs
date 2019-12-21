using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentLife.Controllers
{
    public class NudimTrazimPrevozController : Controller
    {
        public IActionResult NTP()
        {
            return View();
        }
    }
}