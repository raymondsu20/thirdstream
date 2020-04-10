using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdStream.Models
{
    public class Vehicle
    {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
        public VehicleType VehicleType
        {
            get;
            set;
        }
    public virtual ICollection<RaceTrackVehicleCondition> RaceTrackVehicleConditions { get; set; }



  }
}
