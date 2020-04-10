using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdStream.Models;
using ThirdStream.ViewModels;

namespace ThirdStream.Dal
{
  public class EfDal : IDal
  {
    private readonly RaceTrackContext context;
    public EfDal(RaceTrackContext context)
    {
      this.context = context;
    }
    public void AddToTrack(long trackId, IEnumerable<RaceTrackVehicleCondition> raceTrackVehicleConditions)
    {
      this.context.RaceTrackVehicleConditions.AddRange(raceTrackVehicleConditions);
      this.context.SaveChanges();
    }

    public void AddToTrack(long trackId, VehicleType? selectedType, List<CheckedCondition> inspectingCondtions)
    {
      var newVehicle = new Vehicle() { VehicleType = selectedType.Value };
      var newRecords = inspectingCondtions.Select(i => new RaceTrackVehicleCondition()
      {
        RaceTrackId = trackId,
         Checked = i.Checked,
          ConditionId = i.Condition.Id,
           Vehicle = newVehicle
      });
      this.AddToTrack(trackId, newRecords);
    }

    public IList<VehicleType> getAllowedVehicleTypes(long trackId)
    {
      return this.context.RaceTracks.Single(r => r.Id == trackId).AllowedVehicleTypes.Select(t => t.VehicleType).ToList();
    }

    public IEnumerable<Condition> getConditions()
    {
      return this.context.Conditions.ToList();
    }

    public RaceTrack GetRaceTrack(long? id = null)
    {
      return id.HasValue ? this.context.RaceTracks.Single(r => r.Id == id.Value) : this.context.RaceTracks.First();
    }

    public IEnumerable<Condition> getRequiredCondtionsForVehicleType(VehicleType? selectedType)
    {
      var lookups = selectedType.HasValue ? this.context.VehicleTypeCondtionLookUps.Where(l => l.VehicleType == selectedType.Value) : this.context.VehicleTypeCondtionLookUps;
      return this.context.Conditions.Join(lookups, c => c.Id, l => l.ConditionCode,
        (c, l) => c).ToList();
    }

    public IEnumerable<RaceTrackVehicleCondition> GetTrackVehicleConditions(long trackId)
    {
      throw new NotImplementedException();
    }

    public int getTrackVehicleCount(long trackId)
    {
      return this.context.RaceTracks.Single(r => r.Id == trackId).RaceTrackVehicleConditions.Select(c => c.VehicleId).Distinct().Count();
    }

    public IEnumerable<Vehicle> getVehiclesForTrack(int trackId)
    {
      return this.context.RaceTrackVehicleConditions.Where(r => r.RaceTrackId == trackId).Select(r => r.Vehicle).Distinct().ToList();
    }

    public IEnumerable<VehicleTypeCondtionLookUp> GetVehicleTypeCondtionLookUps()
    {
      return this.context.VehicleTypeCondtionLookUps.ToList();
    }
  }
}
