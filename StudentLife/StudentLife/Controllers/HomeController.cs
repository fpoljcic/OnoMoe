using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentLife.Models;

namespace StudentLife.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> DrugaStranica()
        {
            
            return View( "../NudimTrazimPrevoz/nudimTrazimPrevoz");
        }



        public void UpisiStudenta ( [Bind( "StudentID,Ime,Prezime,Email,KorisnickoIme,Password" )] Student student, string Password2 )
        {
            student.Bodovi = 0;
            if (ModelState.IsValid) {

                if (student.Password == Password2) { 
                
                
                
                
                }
            
            
            }


        }

        
    }
}
