using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StudentLife.Models {
    public class RegistrovaniStudent {

        [Required]
        int RegistrovaniStudentId { get; set; }
        [Required]
        string Ime { get; set; }
        [Required]
        string Prezime { get; set; }
        [Required]
        string Email { get; set; }
        [Required]
        string Password { get; set; }
        [Required]
        int bodovi { get; set; }



    }
}
