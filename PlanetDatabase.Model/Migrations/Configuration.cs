using System.Collections.Generic;

namespace PlanetDatabase.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlanetDatabase.Model.PlanetDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PlanetDatabase.Model.PlanetDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            //var sunStar = new Star()
            //{
            //    Name = "Sun",
            //    Planets = new List<Planet>()
            //    {
            //        new Planet()
            //        {
            //            Name = "Earth",
            //            AwayOfStar = 23

            //        },
            //        new Planet()
            //        {
            //            Name = "Mercury",
            //            AwayOfStar = 5.8
            //        },
            //        new Planet()
            //        {
            //            Name = "Venus",
            //            AwayOfStar = 10.8
            //        },
            //        new Planet()
            //        {
            //            Name = "Ceres",
            //            AwayOfStar = 41
            //        },
            //        new Planet()
            //        {
            //            Name = "Jupiter",
            //            AwayOfStar = 78
            //        },
            //        new Planet()
            //        {
            //            Name = "Saturn",
            //            AwayOfStar = 143
            //        },
            //        new Planet()
            //        {
            //            Name = "Uranus",
            //            AwayOfStar = 287
            //        },
            //        new Planet()
            //        {
            //            Name = "Neptune",
            //            AwayOfStar = 450
            //        },
            //        new Planet()
            //        {
            //            Name = "Neptune",
            //            AwayOfStar = 450
            //        },
            //        new Planet()
            //        {
            //            Name = "Pluto",
            //            AwayOfStar = 592
            //        },
            //        new Planet()
            //        {
            //            Name = "Eris",
            //            AwayOfStar = 1015.1
            //        }
            //    }
            //};

            //context.Stars.AddOrUpdate(sunStar);
            //base.Seed(context);
        }
    }
}



