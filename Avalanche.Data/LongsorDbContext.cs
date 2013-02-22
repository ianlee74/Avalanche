using System.Data.Entity;
using Longsor.Data.SampleData;
using Longsor.Model;

namespace Longsor.Data
{
    public class LongsorDbContext:DbContext
    {
        public LongsorDbContext() : base(nameOrConnectionString: "Longsor") {}

        public DbSet<Avalanche> Avalanches { get; set; }
        public DbSet<Solution> Solutions { get; set; }

        static LongsorDbContext()
        {
            // Remove from production.  This will reset the database.
            Database.SetInitializer(new LongsorDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AvalancheConfiguration());
            modelBuilder.Configurations.Add(new SolutionConfiguration());
        }
    }
}
