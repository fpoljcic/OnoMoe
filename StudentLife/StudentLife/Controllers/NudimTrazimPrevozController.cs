using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StudentLife.Models;

namespace StudentLife.Controllers
{
    public class NudimTrazimPrevozController : Controller
    {

        public IActionResult Index()
        {
            return View("nudimTrazimPrevoz");
        }

        public async Task<IActionResult> pretrazi([Bind("datum,vrijeme")] string datum, string vrijeme)
        {
            ViewData["datum"] = datum;
            ViewData["vrijeme"] = vrijeme;
            int i = HttpContext.Session.GetInt32( "id" ).Value;
            ViewData["id"] = i;
            return View("../TrazimVoznju/trazimVoznju");
        }
        
        public  string getIme() {

            return HttpContext.Session.GetString( "user" );
        }

        public async Task<IActionResult> Nudim()
        {
            return View( "../NudimVoznju/nudimVoznju" );
        }
    }
}