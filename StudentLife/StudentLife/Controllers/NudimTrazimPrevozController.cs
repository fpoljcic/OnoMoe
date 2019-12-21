using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentLife.Controllers
{
    public class NudimTrazimPrevozController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> pretrazi([Bind("datum,vrijeme")] string datum, string vrijeme)
        {
            return View("../TrazimVoznju/trazimVoznju");
        }
    }
}