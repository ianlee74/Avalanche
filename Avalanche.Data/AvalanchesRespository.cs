using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Longsor.Model;

namespace Longsor.Data
{
    public class AvalanchesRespository : EFRepository<Avalanche>
    {
        public AvalanchesRespository(DbContext context) : base(context) {}

    }
}
