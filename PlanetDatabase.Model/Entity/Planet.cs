using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetDatabase.Model
{
    public class Planet : IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Distance from the Sun")]
        [Description("Scale: 1 cm = 10 million km")]
        public double AwayOfStar { get; set; }

        public Star System { get; set; }
    }
}
