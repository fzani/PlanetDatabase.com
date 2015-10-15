using PlanetDatabase.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetDatabase.Infrastructure.Repositories
{
    public class PlanetRepository<T, U> : Repository<T>
        where U : IUnitOfWork, new()
        where T : class
    {
        public PlanetRepository() : base(new U()) { }
       
    }
}
