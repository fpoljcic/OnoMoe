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
        public int RegistrovaniStudentId { get; set; }
        public RegistrovaniStudent RegistrovaniStudent { get; set; }
        [Required]
        public DateTime Polazak { get; set; }



     


    }
}
