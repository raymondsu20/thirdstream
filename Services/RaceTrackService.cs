using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdStream.Dal;
using ThirdStream.Models;
using ThirdStream.ViewModels;

namespace ThirdStream.Services
{
  public class RaceTrackService : IRaceTrackService
  {
    private readonly IDal dal;
    public RaceTrackService(IDal dal)
    {
      this.dal = dal;
    }
    public void AddVehicleToTrack(long trackId, RaceTrackInfo trackInfo)
    {
      var track = this.dal.GetRaceTrack(trackId);

      //this is not thread safe
      if (this.dal.getTrackVehicleCount(trackId) >= track.Capacity)
      {
        throw new Exception("Track is full");
      }

      var requiredConditions = this.dal.getRequiredCondtionsForVehicleType(trackInfo.SelectedType);
      var inspectingCondtions = trackInfo.Conditions[trackInfo.SelectedType.Value];
      if (inspectingCondtions.Any(c => !c.Checked))
      {
        throw new Exception("All inspection conditions must be met");
      }

      if (requiredConditions.Count() != inspectingCondtions.Count()
        ||
   requiredConditions.Any(c => inspectingCondtions.All(rc => rc.Condition.Id != c.Id) ))
      {
        throw new Exception("Trying to break the rules?");
      }

      this.dal.AddToTrack(trackId, trackInfo.SelectedType, inspectingCondtions);



    }
    public RaceTrackInfo getRaceTrackInfo(long? id = null)
    {
      var raceTrack = this.dal.GetRaceTrack(id);
      var requiredInspections = this.dal.GetVehicleTypeCondtionLookUps();
      var VehicleTypes = this.dal.getAllowedVehicleTypes(raceTrack.Id);
      var conditions = this.dal.getConditions();
      var vm = new RaceTrackInfo()
      {
        VehicleTypes = VehicleTypes,
        RaceTrackId = raceTrack.Id,
        RaceTrackCapacity = raceTrack.Capacity

      };
      vm.Conditions = VehicleTypes.GroupJoin(requiredInspections,
       v => v, i => i.VehicleType,
      (v,i) => new { Key = v, Value = i })
      .ToDictionary(o => o.Key, o => conditions.Where(c => o.Value.Any(r => r.ConditionCode == c.Id && r.VehicleType == o.Key)).Select(c => new CheckedCondition()
      {
        VehicleType = o.Key,
        Condition = c
      }).ToList());

      return vm;

    }

    public IEnumerable<Vehicle> getVehiclesForTrack(int trackId)
    {
      return this.dal.getVehiclesForTrack(trackId);
    }
  }
}
