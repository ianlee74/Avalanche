using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Longsor.Model;

namespace Longsor.Data
{
    public class SolutionConfiguration : EntityTypeConfiguration<Solution>
    {
        public SolutionConfiguration()
        {
        }
    }
}
