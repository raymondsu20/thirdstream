using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdStream.Models;

namespace ThirdStream.Dal
{
  public static class DbInit
  {
    public static void Init(RaceTrackContext context)
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      var raceTrack = new RaceTrack() { Capacity = 5, AllowedVehicleTypes = new VehicleTypeC[] { new VehicleTypeC { VehicleType = VehicleType.CAR }, new VehicleTypeC() { VehicleType = VehicleType.TRUCK } } };


      context.RaceTracks.Add(raceTrack);

      var conditions = new List<Condition>()
      {
        new Condition(){ Id = "STR", Description = "Tow Strap on the vehicle"},
        new Condition(){ Id = "LIF", Description = "Not lifted more than 5 inches"},
        new Condition(){ Id = "WER", Description = "Less than 85% tire wear"}
      };


      context.Conditions.AddRange(conditions.ToArray());

      context.SaveChanges();

      context.Vehicles.Add(new Vehicle() { VehicleType = VehicleType.CAR });

   
      var conditionLookups = new List<VehicleTypeCondtionLookUp>()
      {
        new VehicleTypeCondtionLookUp(){ VehicleType = VehicleType.CAR, ConditionCode = "WER"},
        new VehicleTypeCondtionLookUp(){ VehicleType = VehicleType.CAR, ConditionCode = "STR"},
        new VehicleTypeCondtionLookUp(){ VehicleType = VehicleType.TRUCK,  ConditionCode = "STR"},
        new VehicleTypeCondtionLookUp(){ VehicleType = VehicleType.TRUCK,  ConditionCode = "LIF"}

      };

      context.VehicleTypeCondtionLookUps.AddRange(conditionLookups.ToArray());

      context.SaveChanges();



      

      context.SaveChanges();



    }

  }
}
