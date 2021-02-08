using Microsoft.EntityFrameworkCore;
using Parcial1_ap1_2017_0826.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_ap1_2017_0826
{
    class Contexto : DbContext
    {
        public DbSet<Ciudad> Ciudad{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Ciudades.db");
        }
    }
}
