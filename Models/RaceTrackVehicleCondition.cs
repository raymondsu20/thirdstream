using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdStream.Models
{
  public class RaceTrackVehicleCondition
  {
    public long RaceTrackId { get; set; }
    public virtual RaceTrack RaceTrack {get;set;}

    
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public string ConditionId { get; set; }
        public virtual Condition Condition { get; set; }

        public bool Checked { get; set; }


    }
}
