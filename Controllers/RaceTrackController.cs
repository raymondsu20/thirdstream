using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThirdStream.Dal;
using ThirdStream.Models;
using ThirdStream.Services;
using ThirdStream.ViewModels;

namespace ThirdStream.Controllers
{
  public class RaceTrackController : Controller
  {

    private readonly IRaceTrackService trackService;

    public RaceTrackController(IRaceTrackService svc)
    {
      this.trackService = svc;
    }
    // GET: RaceTrack
    public ActionResult Index()
    {
     
      return View(this.trackService.getRaceTrackInfo());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(RaceTrackInfo model)
    {
      try
      {
        this.trackService.AddVehicleToTrack(model.RaceTrackId, model);
       
      }
      catch(Exception e)
      {
        ModelState.AddModelError("error", e.Message);
        return View(this.trackService.getRaceTrackInfo());

      }
      ModelState.Clear();
      return View(this.trackService.getRaceTrackInfo());
    }

   
    public PartialViewResult VehicleList(int trackId)
    {
       IEnumerable<Vehicle> vehicles =  this.trackService.getVehiclesForTrack(trackId);
      return PartialView(vehicles);
    }

    
  }
}