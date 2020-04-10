using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdStream.Models;

namespace ThirdStream.ViewModels
{
  public class CheckedCondition
  {
    public VehicleType VehicleType { get; set; }

    public Condition  Condition { get; set; }

    public bool Checked { get; set; }

  }
}
