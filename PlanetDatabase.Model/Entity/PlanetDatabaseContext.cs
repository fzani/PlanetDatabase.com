using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetDatabase.Model
{
    public class PlanetDatabaseContext : DbContext
    {
        public PlanetDatabaseContext()
            : base("PlanetDatabase")  //please verify the connectionstring path on your source
        {
        }

        public DbSet<Star> Stars { get; set; }
        public DbSet<Planet> Planets { get; set; }
    }
}
