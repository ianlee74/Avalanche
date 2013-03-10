using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longsor.Data.SampleData
{
    public class LongsorDatabaseInitializer : DropCreateDatabaseIfModelChanges<LongsorDbContext>
    {
        protected override void Seed(LongsorDbContext context)
        {
            //var avalanches = AddAvalanches(context);


            base.Seed(context);
        }
    }
}
