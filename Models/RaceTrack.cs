using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdStream.Models
{
    public class RaceTrack
    {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
        public int Capacity { get; set; }

    public virtual ICollection<VehicleTypeC> AllowedVehicleTypes { get; set; }

        public virtual ICollection<RaceTrackVehicleCondition>  RaceTrackVehicleConditions {get;set;}
    }
}
