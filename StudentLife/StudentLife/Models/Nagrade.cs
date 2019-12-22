using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentLife.Models {
    public class Nagrade {
        [ScaffoldColumn( false )]
        [Required]
        public int NagradeID {get;set;}
        [Required]
        public string NazivNagrade { get; set; }
        [Required]
        public int BrojBodova { get; set; }

    }
}
