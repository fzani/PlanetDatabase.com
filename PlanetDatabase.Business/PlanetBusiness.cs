using PlanetDatabase.Infrastructure.Base;
using PlanetDatabase.Infrastructure.Repositories;
using PlanetDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetDatabase.Business
{
    public class PlanetBusiness : IPlanetBusiness
    {
        private readonly PlanetRepository<Planet, UnitOfWork<PlanetDatabaseContext>> _repository;

        public PlanetBusiness()
        {
            this._repository = new PlanetRepository<Planet, UnitOfWork<PlanetDatabaseContext>>();
        }

        public List<Planet> GetPlanets()
        {
            //throw new NotImplementedException();
            return _repository.GetAll().ToList();
        }


        public List<Model.Planet> SetPlanet(Model.Planet planet)
        {
            throw new NotImplementedException();
        }

        public List<Model.Planet> GetPlanet(int planetId)
        {
            throw new NotImplementedException();
        }



    }
}
