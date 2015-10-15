using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanetDatabase.Model;

namespace PlanetDatabase.UnitTestProject
{
    [TestClass]
    public class PlanetDatabaseModelUnitTest
    {
        [TestMethod]
        public void TestInstanceDatabaseContext()
        {
            using (var db = new PlanetDatabaseContext())
            {
                var planetList = db.Stars.ToList();

                Assert.IsTrue(planetList != null);
            }
        }
    }
}
