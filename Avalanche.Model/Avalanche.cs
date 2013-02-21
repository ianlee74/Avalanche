using System.Collections.Generic;

namespace Longsor.Model
{
    public class Avalanche
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Avalanche> Avalanches { get; set; } 
        public virtual ICollection<Solution> Solutions { get; set; }
        public Solution ChosenSolution { get; set; }
    }
}
