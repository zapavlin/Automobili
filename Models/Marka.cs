﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Automobili.Models
{
    public class Marka
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
    }
}
