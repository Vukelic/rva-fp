using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Context : DbContext
    {
       public Context() : base("dbConnection2017") {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FlowerPlotIteration> Flowers { get; set; }
        public DbSet<SoilType> Soils { get; set; }
        public DbSet<Flower> FlowersType { get; set; }
    }
}
