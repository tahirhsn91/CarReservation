namespace CarReservation.Core.Migrations
{
    using CarReservation.Core.Constant;
    using CarReservation.Core.Infrastructure;
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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarReservation.Core.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "SuperPowerUser",
                Email = "taiseer.joudeh@mymail.com",
                EmailConfirmed = true,
                FirstName = "Taiseer",
                LastName = "Joudeh"
            };

            manager.Create(user, "MySuperP@ss!");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = UserRoles.SUPER });
                roleManager.Create(new IdentityRole { Name = UserRoles.ADMIN });
                roleManager.Create(new IdentityRole { Name = UserRoles.SUPERVISOR });
                roleManager.Create(new IdentityRole { Name = UserRoles.DRIVER });
            }

            var adminUser = manager.FindByName("SuperPowerUser");

            manager.AddToRoles(adminUser.Id, new string[] { UserRoles.SUPER, UserRoles.ADMIN });
        }
    }
}
