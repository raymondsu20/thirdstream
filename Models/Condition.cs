using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdStream.Models
{
    public class Condition
    {
        public string Id { get; set; }

        public string Description { get; set; }

    public virtual ICollection<RaceTrackVehicleCondition> RaceTrackVehicleConditions { get; set; }
  }
}
