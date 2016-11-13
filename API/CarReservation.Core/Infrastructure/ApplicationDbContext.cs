using CarReservation.Core.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Country> Country { get; set; }

        public DbSet<Color> Color { get; set; }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyLog> CurrencyLog { get; set; }

        public DbSet<VehicleBodyType> VehicleBodyType { get; set; }
        public DbSet<VehicleAssembly> VehicleAssembly { get; set; }
        public DbSet<VehicleTransmission> VehicleTransmission { get; set; }
        public DbSet<VehicleFeature> VehicleFeature { get; set; }
        public DbSet<VehicleMaker> VehicleMaker { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<LocationLagLon> LocationLagLon { get; set; }
        public DbSet<Fare> Fare { get; set; }
        public DbSet<TravelUnit> TravelUnit { get; set; }
        public DbSet<Package> Package { get; set; }

        public DbSet<Account> Account { get; set; }
        public DbSet<AccountLog> AccountLog { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Supervisor> Supervisor { get; set; }
        public DbSet<Driver> Driver { get; set; }

        public DbSet<Ride> Ride { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
