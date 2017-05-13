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

            string emailAddress = "tahir.hassan@gmail.com";
            if (manager.FindByEmail(emailAddress) == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = emailAddress,
                    Email = emailAddress,
                    EmailConfirmed = true,
                    FirstName = "tahir",
                    LastName = "hassan",
                    MobileNumber = "0000000000",
                    CreatedOn = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                };
                manager.Create(user, "Admin123!@#$");

                var adminUser = manager.FindByName(emailAddress);
                manager.AddToRoles(adminUser.Id, new string[] { UserRoles.SUPER, UserRoles.ADMIN });
            }

            if (context.DriverStatus.Count() == 0)
            {
                context.DriverStatus.Add(new Core.Model.DriverStatus { Name = Core.Constant.DriverStatus.UnAvailable, Code = Core.Constant.DriverStatus.UnAvailable, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.DriverStatus.Add(new Core.Model.DriverStatus { Name = Core.Constant.DriverStatus.Available, Code = Core.Constant.DriverStatus.Available, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.DriverStatus.Add(new Core.Model.DriverStatus { Name = Core.Constant.DriverStatus.GoingToPick, Code = Core.Constant.DriverStatus.GoingToPick, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
                context.DriverStatus.Add(new Core.Model.DriverStatus { Name = Core.Constant.DriverStatus.Riding, Code = Core.Constant.DriverStatus.Riding, CreatedBy = "System", CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
            }
        }
    }
}
