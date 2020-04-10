using System.Collections.Generic;
using ThirdStream.Models;
using ThirdStream.ViewModels;

namespace ThirdStream.Services
{
  public interface IRaceTrackService
  {
    void AddVehicleToTrack(long trackId, RaceTrackInfo trackInfo);
    RaceTrackInfo getRaceTrackInfo(long? id = null);
    IEnumerable<Vehicle> getVehiclesForTrack(int trackId);
  }
}