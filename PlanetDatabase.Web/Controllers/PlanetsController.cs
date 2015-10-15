using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlanetDatabase.Business;
using PlanetDatabase.Model;

namespace PlanetDatabase.Web.Controllers
{
    public class PlanetsController : ApiController
    {
        private readonly PlanetBusiness _planetBusiness;


        public PlanetsController()
        {
            _planetBusiness = new PlanetBusiness();
        }
        // GET api/values
        public IEnumerable<Planet> Get()
        {
            return _planetBusiness.GetPlanets();
        }

        // GET api/values/5
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
