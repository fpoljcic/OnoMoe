using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentLife.Models;
using Microsoft.AspNetCore.Http;

namespace StudentLife.Controllers
{
    public class NagradeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["bodovi"] = HttpContext.Session.GetInt32("bodovi");
            return View("nagrade");
        }

        public async Task<IActionResult> skiniBodove(int brb)
        {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["bodovi"] = HttpContext.Session.GetInt32("bodovi");
            Student s;
            using (var db = new DatabaseContext()) {
                s = db.Student.Where(e => e.StudentID == (int)HttpContext.Session.GetInt32("id")).FirstOrDefault();
                if (s.Bodovi < brb) return View("nagrade");
                s.Bodovi -= brb;
                HttpContext.Session.SetInt32("bodovi", s.Bodovi);
                ViewData["id"] = HttpContext.Session.GetInt32("id");
                ViewData["bodovi"] = HttpContext.Session.GetInt32("bodovi");
                db.Update(s);
                await db.SaveChangesAsync();


            }
                return View("nagrade");
        }

       
    }
}