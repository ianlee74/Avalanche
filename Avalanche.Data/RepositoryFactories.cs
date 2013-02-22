using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longsor.Data
{
    public class RepositoryFactories
    {


        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>()
        {
            return dbContext => new EFRepository<T>(dbContext);
        }
    }
}
