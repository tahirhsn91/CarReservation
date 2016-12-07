using CarReservation.Core.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

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

        public DbSet<DistanceUnit> DistanceUnit { get; set; }
        public DbSet<Distance> Distance { get; set; }

        public DbSet<TimeTracker> TimeTracker { get; set; }

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

        public DbSet<PackageTravelUnit> PackageTravelUnit { get; set; }
        public DbSet<PackageVehicleAssembly> PackageVehicleAssembly { get; set; }
        public DbSet<PackageVehicleBodyType> PackageVehicleBodyType { get; set; }
        public DbSet<PackageVehicleFeature> PackageVehicleFeature { get; set; }
        public DbSet<PackageVehicleModel> PackageVehicleModel { get; set; }
        public DbSet<PackageVehicleTransmission> PackageVehicleTransmission { get; set; }

        public DbSet<LocationLagLon> LocationLagLon { get; set; }
        public DbSet<FavouriteLocation> FavouriteLocation { get; set; }
        public DbSet<Fare> Fare { get; set; }
        public DbSet<TravelUnit> TravelUnit { get; set; }
        public DbSet<Package> Package { get; set; }

        public DbSet<Account> Account { get; set; }
        public DbSet<AccountLog> AccountLog { get; set; }

        public DbSet<DriverStatus> DriverStatus { get; set; }
        public DbSet<DriverLocation> DriverLocation { get; set; }
        public DbSet<DriverLocationLog> DriverLocationLog { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Supervisor> Supervisor { get; set; }
        public DbSet<Driver> Driver { get; set; }

        public DbSet<RideStatus> RideStatus { get; set; }
        public DbSet<Ride> Ride { get; set; }

        public DbSet<CreditCard> CreditCard { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
