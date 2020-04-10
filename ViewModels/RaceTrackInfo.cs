using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdStream.Models;

namespace ThirdStream.ViewModels
{
    public class RaceTrackInfo
    {
        public long RaceTrackId { get; set; }
        public int RaceTrackCapacity { get; set; }
        public IList<VehicleType> VehicleTypes { get; set; }
        public Dictionary<VehicleType,List<CheckedCondition>> Conditions {get;set;}
    public VehicleType? SelectedType { get; set; }

 


    }
}
