using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PlanetDatabase.Model
{
    public class Star : IEntityBase
    {   
        public Star()
        {
            Planets = new List<Planet>();
        }

        //[Description("solar system")]
        //SolarSystem,

        //[Description("Alpha Centauri")]
        //AlphaCentauri

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Planet> Planets { get; set; }
    }
}
