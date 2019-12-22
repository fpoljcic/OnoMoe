using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StudentLife.Models;

namespace StudentLife.Controllers
{
    public class NudimVoznjuController : Controller
    {
        public IActionResult Index()
        {
            return View("nudimVoznju");
        }

        public IActionResult PonudiVoznju( [Bind( "name,date,time,cars,pocetni,krajnji" )] string name, string date, string time, int cars, string pocetni, string krajnji) {

            if (pocetni != null && krajnji != null)
            {

                DateTime dateTime = new DateTime( Convert.ToInt32( date.Substring( 0, date.IndexOf( "-" ) ) ), Convert.ToInt32( date.Substring( date.IndexOf( "-" ) + 1, date.Length - date.LastIndexOf( "-" ) - 1 ) ), Convert.ToInt32( date.Substring( date.LastIndexOf( "-" ) + 1 ) ), Convert.ToInt32( time.Substring( 0, time.IndexOf( ":" ) ) ), Convert.ToInt32( time.Substring( time.IndexOf( ":" ) + 1, time.Length - time.LastIndexOf( ":" ) - 1 ) ), 0 );

               
                Voznja v = new Voznja();
                v.StudentID = (int)HttpContext.Session.GetInt32( "id" );
                v.PocetakRute = pocetni;
                v.KrajRute = krajnji;
                v.VrijemePolaska = dateTime;
                Console.WriteLine( v.PocetakRute );
            }
            double a;

            return View();
        }
    }
}