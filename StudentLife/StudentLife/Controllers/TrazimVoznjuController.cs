using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StudentLife.Models;

namespace StudentLife.Controllers
{
    public class TrazimVoznjuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> rezervisiMjesto([Bind( "hiddenId,hiddenId2" )] string hiddenId , string hiddenId2 )
        {
            Marker m = new Marker();
            m.StudentID =  HttpContext.Session.GetInt32("id").Value;
            m.VoznjaID = Int32.Parse(hiddenId);
            m.Koordinate = "[" + hiddenId2 + "]";
            m.Status = 0;
            ViewData["id"] = HttpContext.Session.GetInt32( "id" );

            using (var db = new DatabaseContext()) {
                var test = db.Marker.Where( e => e.VoznjaID == m.VoznjaID && e.StudentID == m.StudentID ).FirstOrDefault();
                if (test != null) { 
                    return View( "../MojeTrazeneVoznje/mojeTrazeneVoznje" );
                }
                db.Add(m);
                await db.SaveChangesAsync();
            
            
            }
            return View("../MojeTrazeneVoznje/mojeTrazeneVoznje");
        }
    }
}