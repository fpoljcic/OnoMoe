using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StudentLife.Models {
    public class Marker {
        [ScaffoldColumn( false )]

        [Required]
        public int MarkerID { get; set; }
        [Required]
        public int StudentID { get; set; }
        public Student Student {get; set;}

        [Required]
        public int VoznjaID { get; set; }
        public  Voznja Voznja { get; set; }
        [Required]
        public string Koordinate { get; set; }


    }
}
