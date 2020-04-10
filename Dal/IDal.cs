using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdStream.Models;
using ThirdStream.ViewModels;

namespace ThirdStream.Dal
{
  public interface IDal
  {
    public RaceTrack GetRaceTrack(long? trackId = null);

    public IEnumerable<VehicleTypeCondtionLookUp> GetVehicleTypeCondtionLookUps();

    public IEnumerable<RaceTrackVehicleCondition> GetTrackVehicleConditions(long trackId);

    public void AddToTrack(long trackId, IEnumerable<RaceTrackVehicleCondition> raceTrackVehicleConditions);
    int getTrackVehicleCount(long trackId);
    IEnumerable<Condition> getRequiredCondtionsForVehicleType(VehicleType? selectedType);
    IList<VehicleType> getAllowedVehicleTypes(long value);
    IEnumerable<Condition> getConditions();
        void AddToTrack(long trackId, VehicleType? selectedType, List<CheckedCondition> inspectingCondtions);
    IEnumerable<Vehicle> getVehiclesForTrack(int trackId);
  }
}
