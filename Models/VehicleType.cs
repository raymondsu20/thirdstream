using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdStream.Models
{
    public enum VehicleType
    {
        CAR,
        TRUCK
    }

  public class VehicleTypeC
  {
    public int Id { get; set; }
    public VehicleType VehicleType { get; set; }
  }
}
