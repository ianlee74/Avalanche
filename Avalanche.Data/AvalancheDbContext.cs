using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Avalanche.Data.SampleData;

namespace Avalanche.Data
{
    public class AvalancheDbContext:DbContext
    {
        public AvalancheDbContext() : base(nameOrConnectionString: "Avalanche") {}

        public DbSet<Avalanche> Avalanches { get; set; }

        static AvalancheDbContext()
        {
            // Remove from production.  This will reset the database.
            Database.SetInitializer(new AvalancheDatabaseInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AvalancheConfiguration());
        }
    }
}
