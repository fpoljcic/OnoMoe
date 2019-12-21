using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StudentLife.Models {
    public class Student {
        [ScaffoldColumn( false )]

            [Required]
        public int StudentID { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        
        public int Bodovi { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }


    }
}
