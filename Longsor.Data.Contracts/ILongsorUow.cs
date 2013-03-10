using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longsor.Data.Contracts
{
    public interface ILongsorUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IAvalanchesRepository Avalanches { get; }
        ISolutionsRepository Solutions { get; }

    }
}
