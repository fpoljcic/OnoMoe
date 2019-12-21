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
       

        public async Task<IActionResult> pretrazi([Bind("datum,vrijeme")] string datum, string vrijeme)
        {
            ViewData["datum"] = datum;
            ViewData["vrijeme"] = vrijeme;
            return View("../TrazimVoznju/trazimVoznju");
        }
        
        public  string getIme() {

            return HttpContext.Session.GetString( "user" );
        }
    }
}