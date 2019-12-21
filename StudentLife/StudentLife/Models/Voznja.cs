using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentLife.Models {
    public class Voznja {
        [ScaffoldColumn(false)]

        [Required]
        public int VoznjaID { get; set; }
        [Required]
        public int StudentID { get; set; }
        public Student Student { get; set; }
        [Required]
        public DateTime VrijemePolaska { get; set; }
        [Required]
        public string PocetakRute { get; set; }
        [Required]
        public string KrajRute { get; set; }

        [Required]
        public int BrojMjesta { get; set; }



     


    }
}
