using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentLife.Models;

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

        public async Task<IActionResult> potvrdi([Bind("poljeH")] string poljeH)
        {
            string[] poljeNiz = poljeH.Split(",");
            string koord = "[" + poljeNiz[0] + "," + poljeNiz[1] + "]";
            using (var db = new DatabaseContext())
            {
                Marker marker = db.Marker.Where(m => m.Koordinate.Equals(koord)).FirstOrDefault();
                marker.Status = 1;
                db.Update(marker);
                await db.SaveChangesAsync();
            }
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            return View("../MojePonudjeneVoznje/mojePonudjeneVoznje");
        }
    }
}