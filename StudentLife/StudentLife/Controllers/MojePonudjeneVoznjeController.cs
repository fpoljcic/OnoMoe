﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentLife.Controllers
{
    public class MojePonudjeneVoznjeController : Controller
    {
        public IActionResult Index()
        {
            return View("mojePonudjeneVoznje");
        }

        public IActionResult logout()
        {
            return View("../Home/Index");
        }
    }
}