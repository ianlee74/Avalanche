using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Longsor.Model;

namespace Longsor.Data
{
    public class AvalancheConfiguration : EntityTypeConfiguration<Avalanche>
    {
        public AvalancheConfiguration()
        {
            /* This is where we setup relationships.
             * Ex.  Session has 1 Speaker, Speaker has many Session records
             HasRequired(s => s.Speaker)
                .WithMany(p => p.SpeakerSessions)
                .HasForeignKey(s => s.SpeakerId);
             */

            HasMany(a => a.Children)
                .WithRequiredPrinciple();

            HasMany(t => t.Solutions)
                .WithRequired(t => t.Id)
                .HasForeignKey(t => t.AvalancheId);
        }
    }
}
