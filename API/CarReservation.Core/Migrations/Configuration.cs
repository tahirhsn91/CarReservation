namespace CarReservation.Core.Migrations
{
    using CarReservation.Core.Constant;
    using CarReservation.Core.Infrastructure;
    using CarReservation.Core.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarReservation.Core.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarReservation.Core.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = UserRoles.SUPER });
                roleManager.Create(new IdentityRole { Name = UserRoles.ADMIN });
                roleManager.Create(new IdentityRole { Name = UserRoles.SUPERVISOR });
                roleManager.Create(new IdentityRole { Name = UserRoles.DRIVER });
                roleManager.Create(new IdentityRole { Name = UserRoles.CUSTOMER });
            }

            string emailAddress = "Admin@gmail.com";
            if (manager.FindByEmail(emailAddress) == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = emailAddress,
                    Email = emailAddress,
                    EmailConfirmed = true,
                    FirstName = "tahir",
                    LastName = "Admin",
                    MobileNumber = "0000000000",
                    CreatedOn = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                };
                manager.Create(user, "tahir123");

                var adminUser = manager.FindByName(emailAddress);
                manager.AddToRoles(adminUser.Id, new string[] { UserRoles.ADMIN });
            }

            if (context.DriverStatus.Count() == 0)
            {
                context.DriverStatus.Add(new Core.Model.DriverStatus { Name = Core.Constant.DriverStatus.UnAvailable, Code = Core.Constant.DriverStatus.UnAvailable, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.DriverStatus.Add(new Core.Model.DriverStatus { Name = Core.Constant.DriverStatus.Available, Code = Core.Constant.DriverStatus.Available, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.DriverStatus.Add(new Core.Model.DriverStatus { Name = Core.Constant.DriverStatus.GoingToPick, Code = Core.Constant.DriverStatus.GoingToPick, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.DriverStatus.Add(new Core.Model.DriverStatus { Name = Core.Constant.DriverStatus.Riding, Code = Core.Constant.DriverStatus.Riding, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
            }

            if (context.RideStatus.Count() == 0)
            {
                context.RideStatus.Add(new Core.Model.RideStatus { Name = Core.Constant.RideStatus.Waiting, Code = Core.Constant.RideStatus.Waiting, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.RideStatus.Add(new Core.Model.RideStatus { Name = Core.Constant.RideStatus.Riding, Code = Core.Constant.RideStatus.Riding, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.RideStatus.Add(new Core.Model.RideStatus { Name = Core.Constant.RideStatus.WaitingForPayment, Code = Core.Constant.RideStatus.WaitingForPayment, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.RideStatus.Add(new Core.Model.RideStatus { Name = Core.Constant.RideStatus.RideOver, Code = Core.Constant.RideStatus.RideOver, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
            }

            if (context.DistanceUnit.Count() == 0)
            {
                context.DistanceUnit.Add(new Core.Model.DistanceUnit { Name = Core.Constant.DistanceUnit.Kilometer, Code = Core.Constant.DistanceUnit.Kilometer, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.DistanceUnit.Add(new Core.Model.DistanceUnit { Name = Core.Constant.DistanceUnit.Meter, Code = Core.Constant.DistanceUnit.Meter, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
            }

            if (context.TravelUnit.Count() == 0)
            {
                context.TravelUnit.Add(new Core.Model.TravelUnit { Name = Core.Constant.TravelUnit.PerKilometer, Code = Core.Constant.TravelUnit.PerKilometer, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.TravelUnit.Add(new Core.Model.TravelUnit { Name = Core.Constant.TravelUnit.PerMeter, Code = Core.Constant.TravelUnit.PerMeter, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.TravelUnit.Add(new Core.Model.TravelUnit { Name = Core.Constant.TravelUnit.PerDay, Code = Core.Constant.TravelUnit.PerDay, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.TravelUnit.Add(new Core.Model.TravelUnit { Name = Core.Constant.TravelUnit.PerHour, Code = Core.Constant.TravelUnit.PerHour, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.TravelUnit.Add(new Core.Model.TravelUnit { Name = Core.Constant.TravelUnit.PerMinute, Code = Core.Constant.TravelUnit.PerMinute, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.TravelUnit.Add(new Core.Model.TravelUnit { Name = Core.Constant.TravelUnit.PerMilliseconds, Code = Core.Constant.TravelUnit.PerMilliseconds, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
            }
        }
    }
}
