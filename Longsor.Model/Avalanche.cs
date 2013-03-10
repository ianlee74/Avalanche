using System.Collections.Generic;

namespace Longsor.Model
{
    public class Avalanche
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Avalanche> ParentAvalanches { get; set; }
        public virtual ICollection<Avalanche> Avalanches { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }
    }
}
