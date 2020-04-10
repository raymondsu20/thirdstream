using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdStream.Models;

namespace ThirdStream.Dal
{
  public class RaceTrackContext : DbContext
  {
    public RaceTrackContext(DbContextOptions<RaceTrackContext> options)
           : base(options)
    {
     
    }


   

    public DbSet<RaceTrack> RaceTracks { get; set; }

    public DbSet<Condition> Conditions { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<RaceTrackVehicleCondition> RaceTrackVehicleConditions { get; set; }

    public DbSet<VehicleTypeCondtionLookUp> VehicleTypeCondtionLookUps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      

      modelBuilder.Entity<RaceTrackVehicleCondition>()
          .HasKey(c => new { c.RaceTrackId,c.VehicleId,c.ConditionId });


    }
  }

}
