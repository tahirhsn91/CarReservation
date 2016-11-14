namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MissingSetupEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleAssemblies", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.VehicleBodyTypes", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.VehicleFeatures", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.VehicleModels", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.VehicleTransmissions", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.TravelUnits", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.TravelUnits", "Package_Id", "dbo.Packages");
            DropIndex("dbo.VehicleAssemblies", new[] { "Package_Id" });
            DropIndex("dbo.VehicleBodyTypes", new[] { "Package_Id" });
            DropIndex("dbo.VehicleFeatures", new[] { "Package_Id" });
            DropIndex("dbo.VehicleModels", new[] { "Package_Id" });
            DropIndex("dbo.VehicleTransmissions", new[] { "Package_Id" });
            DropIndex("dbo.TravelUnits", new[] { "Currency_Id" });
            DropIndex("dbo.TravelUnits", new[] { "Package_Id" });
            CreateTable(
                "dbo.Distances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalDistance = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DistanceUnits", t => t.Unit_Id)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "dbo.DistanceUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriverStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriverLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Driver_Id = c.Int(),
                        Location_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .ForeignKey("dbo.LocationLagLons", t => t.Location_Id)
                .ForeignKey("dbo.DriverStatus", t => t.Status_Id)
                .Index(t => t.Driver_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.DriverLocationLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Driver_Id = c.Int(),
                        Location_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .ForeignKey("dbo.LocationLagLons", t => t.Location_Id)
                .ForeignKey("dbo.DriverStatus", t => t.Status_Id)
                .Index(t => t.Driver_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.PackageTravelUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Currency_Id = c.Int(),
                        Package_Id = c.Int(),
                        TravelUnit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.TravelUnits", t => t.TravelUnit_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.TravelUnit_Id);
            
            CreateTable(
                "dbo.PackageVehicleAssemblies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Package_Id = c.Int(),
                        VehicleAssembly_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.VehicleAssemblies", t => t.VehicleAssembly_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.VehicleAssembly_Id);
            
            CreateTable(
                "dbo.PackageVehicleBodyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Package_Id = c.Int(),
                        VehicleBodyType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.VehicleBodyTypes", t => t.VehicleBodyType_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.VehicleBodyType_Id);
            
            CreateTable(
                "dbo.PackageVehicleFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Package_Id = c.Int(),
                        VehicleFeature_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.VehicleFeatures", t => t.VehicleFeature_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.VehicleFeature_Id);
            
            CreateTable(
                "dbo.PackageVehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Package_Id = c.Int(),
                        VehicleModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModel_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.VehicleModel_Id);
            
            CreateTable(
                "dbo.PackageVehicleTransmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Package_Id = c.Int(),
                        VehicleTransmission_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.VehicleTransmissions", t => t.VehicleTransmission_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.VehicleTransmission_Id);
            
            CreateTable(
                "dbo.RideStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeTrackers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Currencies", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Currencies", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Cities", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Colors", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Colors", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Countries", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.States", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.States", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Drivers", "Status_Id", c => c.Int());
            AddColumn("dbo.VehicleAssemblies", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleAssemblies", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleBodyTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleBodyTypes", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleFeatures", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleFeatures", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleModels", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleModels", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleMakers", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleMakers", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleTransmissions", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.VehicleTransmissions", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TravelUnits", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TravelUnits", "Code", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Rides", "RideDistance_Id", c => c.Int());
            AddColumn("dbo.Rides", "RideStatus_Id", c => c.Int());
            AddColumn("dbo.Rides", "Ride_Id", c => c.Int());
            AddColumn("dbo.Rides", "TimeTaken_Id", c => c.Int());
            CreateIndex("dbo.Drivers", "Status_Id");
            CreateIndex("dbo.Rides", "RideDistance_Id");
            CreateIndex("dbo.Rides", "RideStatus_Id");
            CreateIndex("dbo.Rides", "Ride_Id");
            CreateIndex("dbo.Rides", "TimeTaken_Id");
            AddForeignKey("dbo.Drivers", "Status_Id", "dbo.DriverStatus", "Id");
            AddForeignKey("dbo.Rides", "RideDistance_Id", "dbo.Distances", "Id");
            AddForeignKey("dbo.Rides", "RideStatus_Id", "dbo.RideStatus", "Id");
            AddForeignKey("dbo.Rides", "Ride_Id", "dbo.Rides", "Id");
            AddForeignKey("dbo.Rides", "TimeTaken_Id", "dbo.TimeTrackers", "Id");
            DropColumn("dbo.Drivers", "IsAvailable");
            DropColumn("dbo.VehicleAssemblies", "Package_Id");
            DropColumn("dbo.VehicleBodyTypes", "Package_Id");
            DropColumn("dbo.VehicleFeatures", "Package_Id");
            DropColumn("dbo.VehicleModels", "Package_Id");
            DropColumn("dbo.VehicleTransmissions", "Package_Id");
            DropColumn("dbo.TravelUnits", "Rate");
            DropColumn("dbo.TravelUnits", "Currency_Id");
            DropColumn("dbo.TravelUnits", "Package_Id");
            DropColumn("dbo.Rides", "TotalDistance");
            DropColumn("dbo.Rides", "StartTime");
            DropColumn("dbo.Rides", "EndTime");
            DropColumn("dbo.Rides", "RideStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rides", "RideStatus", c => c.String());
            AddColumn("dbo.Rides", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rides", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rides", "TotalDistance", c => c.Double(nullable: false));
            AddColumn("dbo.TravelUnits", "Package_Id", c => c.Int());
            AddColumn("dbo.TravelUnits", "Currency_Id", c => c.Int());
            AddColumn("dbo.TravelUnits", "Rate", c => c.Double(nullable: false));
            AddColumn("dbo.VehicleTransmissions", "Package_Id", c => c.Int());
            AddColumn("dbo.VehicleModels", "Package_Id", c => c.Int());
            AddColumn("dbo.VehicleFeatures", "Package_Id", c => c.Int());
            AddColumn("dbo.VehicleBodyTypes", "Package_Id", c => c.Int());
            AddColumn("dbo.VehicleAssemblies", "Package_Id", c => c.Int());
            AddColumn("dbo.Drivers", "IsAvailable", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Rides", "TimeTaken_Id", "dbo.TimeTrackers");
            DropForeignKey("dbo.Rides", "Ride_Id", "dbo.Rides");
            DropForeignKey("dbo.Rides", "RideStatus_Id", "dbo.RideStatus");
            DropForeignKey("dbo.Rides", "RideDistance_Id", "dbo.Distances");
            DropForeignKey("dbo.PackageVehicleTransmissions", "VehicleTransmission_Id", "dbo.VehicleTransmissions");
            DropForeignKey("dbo.PackageVehicleTransmissions", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.PackageVehicleModels", "VehicleModel_Id", "dbo.VehicleModels");
            DropForeignKey("dbo.PackageVehicleModels", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.PackageVehicleFeatures", "VehicleFeature_Id", "dbo.VehicleFeatures");
            DropForeignKey("dbo.PackageVehicleFeatures", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.PackageVehicleBodyTypes", "VehicleBodyType_Id", "dbo.VehicleBodyTypes");
            DropForeignKey("dbo.PackageVehicleBodyTypes", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.PackageVehicleAssemblies", "VehicleAssembly_Id", "dbo.VehicleAssemblies");
            DropForeignKey("dbo.PackageVehicleAssemblies", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.PackageTravelUnits", "TravelUnit_Id", "dbo.TravelUnits");
            DropForeignKey("dbo.PackageTravelUnits", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.PackageTravelUnits", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.DriverLocationLogs", "Status_Id", "dbo.DriverStatus");
            DropForeignKey("dbo.DriverLocationLogs", "Location_Id", "dbo.LocationLagLons");
            DropForeignKey("dbo.DriverLocationLogs", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.DriverLocations", "Status_Id", "dbo.DriverStatus");
            DropForeignKey("dbo.DriverLocations", "Location_Id", "dbo.LocationLagLons");
            DropForeignKey("dbo.DriverLocations", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "Status_Id", "dbo.DriverStatus");
            DropForeignKey("dbo.Distances", "Unit_Id", "dbo.DistanceUnits");
            DropIndex("dbo.Rides", new[] { "TimeTaken_Id" });
            DropIndex("dbo.Rides", new[] { "Ride_Id" });
            DropIndex("dbo.Rides", new[] { "RideStatus_Id" });
            DropIndex("dbo.Rides", new[] { "RideDistance_Id" });
            DropIndex("dbo.PackageVehicleTransmissions", new[] { "VehicleTransmission_Id" });
            DropIndex("dbo.PackageVehicleTransmissions", new[] { "Package_Id" });
            DropIndex("dbo.PackageVehicleModels", new[] { "VehicleModel_Id" });
            DropIndex("dbo.PackageVehicleModels", new[] { "Package_Id" });
            DropIndex("dbo.PackageVehicleFeatures", new[] { "VehicleFeature_Id" });
            DropIndex("dbo.PackageVehicleFeatures", new[] { "Package_Id" });
            DropIndex("dbo.PackageVehicleBodyTypes", new[] { "VehicleBodyType_Id" });
            DropIndex("dbo.PackageVehicleBodyTypes", new[] { "Package_Id" });
            DropIndex("dbo.PackageVehicleAssemblies", new[] { "VehicleAssembly_Id" });
            DropIndex("dbo.PackageVehicleAssemblies", new[] { "Package_Id" });
            DropIndex("dbo.PackageTravelUnits", new[] { "TravelUnit_Id" });
            DropIndex("dbo.PackageTravelUnits", new[] { "Package_Id" });
            DropIndex("dbo.PackageTravelUnits", new[] { "Currency_Id" });
            DropIndex("dbo.DriverLocationLogs", new[] { "Status_Id" });
            DropIndex("dbo.DriverLocationLogs", new[] { "Location_Id" });
            DropIndex("dbo.DriverLocationLogs", new[] { "Driver_Id" });
            DropIndex("dbo.DriverLocations", new[] { "Status_Id" });
            DropIndex("dbo.DriverLocations", new[] { "Location_Id" });
            DropIndex("dbo.DriverLocations", new[] { "Driver_Id" });
            DropIndex("dbo.Drivers", new[] { "Status_Id" });
            DropIndex("dbo.Distances", new[] { "Unit_Id" });
            DropColumn("dbo.Rides", "TimeTaken_Id");
            DropColumn("dbo.Rides", "Ride_Id");
            DropColumn("dbo.Rides", "RideStatus_Id");
            DropColumn("dbo.Rides", "RideDistance_Id");
            DropColumn("dbo.TravelUnits", "Code");
            DropColumn("dbo.TravelUnits", "Name");
            DropColumn("dbo.VehicleTransmissions", "Code");
            DropColumn("dbo.VehicleTransmissions", "Name");
            DropColumn("dbo.VehicleMakers", "Code");
            DropColumn("dbo.VehicleMakers", "Name");
            DropColumn("dbo.VehicleModels", "Code");
            DropColumn("dbo.VehicleModels", "Name");
            DropColumn("dbo.VehicleFeatures", "Code");
            DropColumn("dbo.VehicleFeatures", "Name");
            DropColumn("dbo.VehicleBodyTypes", "Code");
            DropColumn("dbo.VehicleBodyTypes", "Name");
            DropColumn("dbo.VehicleAssemblies", "Code");
            DropColumn("dbo.VehicleAssemblies", "Name");
            DropColumn("dbo.Drivers", "Status_Id");
            DropColumn("dbo.States", "Code");
            DropColumn("dbo.States", "Name");
            DropColumn("dbo.Countries", "Code");
            DropColumn("dbo.Countries", "Name");
            DropColumn("dbo.Colors", "Code");
            DropColumn("dbo.Colors", "Name");
            DropColumn("dbo.Cities", "Code");
            DropColumn("dbo.Cities", "Name");
            DropColumn("dbo.Currencies", "Code");
            DropColumn("dbo.Currencies", "Name");
            DropTable("dbo.TimeTrackers");
            DropTable("dbo.RideStatus");
            DropTable("dbo.PackageVehicleTransmissions");
            DropTable("dbo.PackageVehicleModels");
            DropTable("dbo.PackageVehicleFeatures");
            DropTable("dbo.PackageVehicleBodyTypes");
            DropTable("dbo.PackageVehicleAssemblies");
            DropTable("dbo.PackageTravelUnits");
            DropTable("dbo.DriverLocationLogs");
            DropTable("dbo.DriverLocations");
            DropTable("dbo.DriverStatus");
            DropTable("dbo.DistanceUnits");
            DropTable("dbo.Distances");
            CreateIndex("dbo.TravelUnits", "Package_Id");
            CreateIndex("dbo.TravelUnits", "Currency_Id");
            CreateIndex("dbo.VehicleTransmissions", "Package_Id");
            CreateIndex("dbo.VehicleModels", "Package_Id");
            CreateIndex("dbo.VehicleFeatures", "Package_Id");
            CreateIndex("dbo.VehicleBodyTypes", "Package_Id");
            CreateIndex("dbo.VehicleAssemblies", "Package_Id");
            AddForeignKey("dbo.TravelUnits", "Package_Id", "dbo.Packages", "Id");
            AddForeignKey("dbo.TravelUnits", "Currency_Id", "dbo.Currencies", "Id");
            AddForeignKey("dbo.VehicleTransmissions", "Package_Id", "dbo.Packages", "Id");
            AddForeignKey("dbo.VehicleModels", "Package_Id", "dbo.Packages", "Id");
            AddForeignKey("dbo.VehicleFeatures", "Package_Id", "dbo.Packages", "Id");
            AddForeignKey("dbo.VehicleBodyTypes", "Package_Id", "dbo.Packages", "Id");
            AddForeignKey("dbo.VehicleAssemblies", "Package_Id", "dbo.Packages", "Id");
        }
    }
}
