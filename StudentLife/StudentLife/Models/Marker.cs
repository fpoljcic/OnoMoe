using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StudentLife.Models {
    public class Marker {
        [ScaffoldColumn( false )]

        [Required]
        public int MarkerId { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student {get; set;}

        [Required]
        public int VoznjaId { get; set; }
        public  Voznja Voznja { get; set; }


    }
}
