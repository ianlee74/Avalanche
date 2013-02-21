using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longsor.Data.SampleData
{
    public class AvalancheDatabaseInitializer : DropCreateDatabaseIfModelChanges<AvalancheDbContext>
    {
        protected override void Seed(AvalancheDbContext context)
        {
            //var avalanches = AddAvalanches(context);


            base.Seed(context);
        }
    }
}
