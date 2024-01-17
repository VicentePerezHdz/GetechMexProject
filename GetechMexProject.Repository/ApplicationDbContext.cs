using GetechMexProjecModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetechMexProject.Repository
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "GetechMexDatabase");
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}
