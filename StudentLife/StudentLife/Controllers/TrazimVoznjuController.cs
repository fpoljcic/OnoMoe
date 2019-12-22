using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentLife.Controllers
{
    public class TrazimVoznjuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> rezervisiMjesto([Bind( "hiddenId" )] string hiddenId )
        {
            
            return View("Index","MojeTrazeneVoznje");
        }
    }
}