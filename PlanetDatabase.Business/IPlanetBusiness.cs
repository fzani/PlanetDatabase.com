using PlanetDatabase.Infrastructure.Base;
using PlanetDatabase.Infrastructure.Repositories;
using PlanetDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetDatabase.Business
{
    interface IPlanetBusiness
    {
        List<Planet> GetPlanets();

        List<Planet> SetPlanet(Planet planet);

        List<Planet> GetPlanet(int planetId);
    }
}
