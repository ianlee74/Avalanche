using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longsor.Data
{
    public class RepositoryProvider
    {

        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            object repoObj;
            Repositories.TryGetValue(typeof (T), out repoObj);
            if (repoObj != null)
            {
                return (T) repoObj;
            }
        }
    }
}
