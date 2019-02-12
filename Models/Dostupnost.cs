using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Automobili.Models
{
    public class Dostupnost
    {
        public int Id { get; set; }

        public int MarkaId { get; set; }
        public Marka MarkaAutomobila { get; set; }

        [Required]
        public string Tip { get; set; }

        [Required]
        public string GodinaProzvodnje { get; set; }

        [Required]
        public string BenzinDizel { get; set; }

        [Required]
        public int BrojBrzina { get; set; }

        [Required]
        public String Kontakt { get; set; }
    }
}
