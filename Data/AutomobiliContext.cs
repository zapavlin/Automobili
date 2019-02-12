using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Automobili.Models;

namespace Automobili.Models
{
    public class AutomobiliContext : DbContext
    {
        public AutomobiliContext (DbContextOptions<AutomobiliContext> options)
            : base(options)
        {
        }

        public DbSet<Automobili.Models.Marka> Marka { get; set; }

        public DbSet<Automobili.Models.Dostupnost> Dostupnost { get; set; }
    }
}
