namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Drivers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Supervisors", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropIndex("dbo.Drivers", new[] { "User_Id" });
            DropIndex("dbo.Supervisors", new[] { "User_Id" });
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Currency_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Double(nullable: false),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
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
                "dbo.AccountLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        debit = c.Double(nullable: false),
                        credit = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Account_Id = c.Int(),
                        Currency_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.CurrencyLogs", t => t.Currency_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CurrencyLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Double(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Colors",
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
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        CVV = c.String(nullable: false),
                        CardHolderName = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Country_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Country_Id)
                .Index(t => t.User_Id);
            
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
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        PassengerCapacity = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Assembly_Id = c.Int(),
                        BodyType_Id = c.Int(),
                        City_Id = c.Int(),
                        Color_Id = c.Int(),
                        Country_Id = c.Int(),
                        Model_Id = c.Int(),
                        Package_Id = c.Int(),
                        State_Id = c.Int(),
                        Transmission_Id = c.Int(),
                        Driver_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleAssemblies", t => t.Assembly_Id)
                .ForeignKey("dbo.VehicleBodyTypes", t => t.BodyType_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Colors", t => t.Color_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.VehicleModels", t => t.Model_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .ForeignKey("dbo.VehicleTransmissions", t => t.Transmission_Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .Index(t => t.Assembly_Id)
                .Index(t => t.BodyType_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Color_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Model_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.State_Id)
                .Index(t => t.Transmission_Id)
                .Index(t => t.Driver_Id);
            
            CreateTable(
                "dbo.VehicleAssemblies",
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
                "dbo.VehicleBodyTypes",
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
                "dbo.VehicleFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 250),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.VehicleModels",
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
                        Maker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleMakers", t => t.Maker_Id, cascadeDelete: true)
                .Index(t => t.Maker_Id);
            
            CreateTable(
                "dbo.VehicleMakers",
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
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        StartFare_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fares", t => t.StartFare_Id)
                .Index(t => t.StartFare_Id);
            
            CreateTable(
                "dbo.Fares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalFare = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Currency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .Index(t => t.Currency_Id);
            
            CreateTable(
                "dbo.VehicleTransmissions",
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
                "dbo.LocationLagLons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.TravelUnits",
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
                        Ride_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rides", t => t.Ride_Id)
                .Index(t => t.Ride_Id);
            
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
                "dbo.Rides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ApproximateFare_Id = c.Int(),
                        Customer_Id = c.Int(),
                        Destination_Id = c.Int(),
                        Driver_Id = c.Int(),
                        Package_Id = c.Int(),
                        RideDistance_Id = c.Int(),
                        RideStatus_Id = c.Int(),
                        Ride_Id = c.Int(),
                        Source_Id = c.Int(),
                        TimeTaken_Id = c.Int(),
                        TotalFare_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fares", t => t.ApproximateFare_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.LocationLagLons", t => t.Destination_Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.Distances", t => t.RideDistance_Id)
                .ForeignKey("dbo.RideStatus", t => t.RideStatus_Id)
                .ForeignKey("dbo.Rides", t => t.Ride_Id)
                .ForeignKey("dbo.LocationLagLons", t => t.Source_Id)
                .ForeignKey("dbo.TimeTrackers", t => t.TimeTaken_Id)
                .ForeignKey("dbo.Fares", t => t.TotalFare_Id)
                .Index(t => t.ApproximateFare_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Destination_Id)
                .Index(t => t.Driver_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.RideDistance_Id)
                .Index(t => t.RideStatus_Id)
                .Index(t => t.Ride_Id)
                .Index(t => t.Source_Id)
                .Index(t => t.TimeTaken_Id)
                .Index(t => t.TotalFare_Id);
            
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
            
            AddColumn("dbo.Customers", "Account_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "MobileNumber", c => c.String());
            AddColumn("dbo.Drivers", "Account_Id", c => c.Int());
            AddColumn("dbo.Drivers", "ActiveVehicle_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Drivers", "Status_Id", c => c.Int());
            AlterColumn("dbo.Customers", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Drivers", "Address", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Drivers", "NICNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Drivers", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Supervisors", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Customers", "Account_Id");
            CreateIndex("dbo.Customers", "User_Id");
            CreateIndex("dbo.Drivers", "Account_Id");
            CreateIndex("dbo.Drivers", "ActiveVehicle_Id");
            CreateIndex("dbo.Drivers", "Status_Id");
            CreateIndex("dbo.Drivers", "User_Id");
            CreateIndex("dbo.Supervisors", "User_Id");
            AddForeignKey("dbo.Customers", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Drivers", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Drivers", "ActiveVehicle_Id", "dbo.Vehicles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Drivers", "Status_Id", "dbo.DriverStatus", "Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Drivers", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Supervisors", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supervisors", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Drivers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TravelUnits", "Ride_Id", "dbo.Rides");
            DropForeignKey("dbo.Rides", "TotalFare_Id", "dbo.Fares");
            DropForeignKey("dbo.Rides", "TimeTaken_Id", "dbo.TimeTrackers");
            DropForeignKey("dbo.Rides", "Source_Id", "dbo.LocationLagLons");
            DropForeignKey("dbo.Rides", "Ride_Id", "dbo.Rides");
            DropForeignKey("dbo.Rides", "RideStatus_Id", "dbo.RideStatus");
            DropForeignKey("dbo.Rides", "RideDistance_Id", "dbo.Distances");
            DropForeignKey("dbo.Rides", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Rides", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Rides", "Destination_Id", "dbo.LocationLagLons");
            DropForeignKey("dbo.Rides", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rides", "ApproximateFare_Id", "dbo.Fares");
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
            DropForeignKey("dbo.Vehicles", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "Status_Id", "dbo.DriverStatus");
            DropForeignKey("dbo.Drivers", "ActiveVehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Transmission_Id", "dbo.VehicleTransmissions");
            DropForeignKey("dbo.Vehicles", "State_Id", "dbo.States");
            DropForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Packages", "StartFare_Id", "dbo.Fares");
            DropForeignKey("dbo.Fares", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Vehicles", "Model_Id", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "Maker_Id", "dbo.VehicleMakers");
            DropForeignKey("dbo.VehicleFeatures", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Vehicles", "Color_Id", "dbo.Colors");
            DropForeignKey("dbo.Vehicles", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Vehicles", "BodyType_Id", "dbo.VehicleBodyTypes");
            DropForeignKey("dbo.Vehicles", "Assembly_Id", "dbo.VehicleAssemblies");
            DropForeignKey("dbo.Drivers", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Distances", "Unit_Id", "dbo.DistanceUnits");
            DropForeignKey("dbo.Customers", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.CreditCards", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CreditCards", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.AccountLogs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccountLogs", "Currency_Id", "dbo.CurrencyLogs");
            DropForeignKey("dbo.CurrencyLogs", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.AccountLogs", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Currencies", "CountryId", "dbo.Countries");
            DropIndex("dbo.Supervisors", new[] { "User_Id" });
            DropIndex("dbo.Rides", new[] { "TotalFare_Id" });
            DropIndex("dbo.Rides", new[] { "TimeTaken_Id" });
            DropIndex("dbo.Rides", new[] { "Source_Id" });
            DropIndex("dbo.Rides", new[] { "Ride_Id" });
            DropIndex("dbo.Rides", new[] { "RideStatus_Id" });
            DropIndex("dbo.Rides", new[] { "RideDistance_Id" });
            DropIndex("dbo.Rides", new[] { "Package_Id" });
            DropIndex("dbo.Rides", new[] { "Driver_Id" });
            DropIndex("dbo.Rides", new[] { "Destination_Id" });
            DropIndex("dbo.Rides", new[] { "Customer_Id" });
            DropIndex("dbo.Rides", new[] { "ApproximateFare_Id" });
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
            DropIndex("dbo.TravelUnits", new[] { "Ride_Id" });
            DropIndex("dbo.PackageTravelUnits", new[] { "TravelUnit_Id" });
            DropIndex("dbo.PackageTravelUnits", new[] { "Package_Id" });
            DropIndex("dbo.PackageTravelUnits", new[] { "Currency_Id" });
            DropIndex("dbo.DriverLocationLogs", new[] { "Status_Id" });
            DropIndex("dbo.DriverLocationLogs", new[] { "Location_Id" });
            DropIndex("dbo.DriverLocationLogs", new[] { "Driver_Id" });
            DropIndex("dbo.DriverLocations", new[] { "Status_Id" });
            DropIndex("dbo.DriverLocations", new[] { "Location_Id" });
            DropIndex("dbo.DriverLocations", new[] { "Driver_Id" });
            DropIndex("dbo.Fares", new[] { "Currency_Id" });
            DropIndex("dbo.Packages", new[] { "StartFare_Id" });
            DropIndex("dbo.VehicleModels", new[] { "Maker_Id" });
            DropIndex("dbo.VehicleFeatures", new[] { "Vehicle_Id" });
            DropIndex("dbo.Vehicles", new[] { "Driver_Id" });
            DropIndex("dbo.Vehicles", new[] { "Transmission_Id" });
            DropIndex("dbo.Vehicles", new[] { "State_Id" });
            DropIndex("dbo.Vehicles", new[] { "Package_Id" });
            DropIndex("dbo.Vehicles", new[] { "Model_Id" });
            DropIndex("dbo.Vehicles", new[] { "Country_Id" });
            DropIndex("dbo.Vehicles", new[] { "Color_Id" });
            DropIndex("dbo.Vehicles", new[] { "City_Id" });
            DropIndex("dbo.Vehicles", new[] { "BodyType_Id" });
            DropIndex("dbo.Vehicles", new[] { "Assembly_Id" });
            DropIndex("dbo.Drivers", new[] { "User_Id" });
            DropIndex("dbo.Drivers", new[] { "Status_Id" });
            DropIndex("dbo.Drivers", new[] { "ActiveVehicle_Id" });
            DropIndex("dbo.Drivers", new[] { "Account_Id" });
            DropIndex("dbo.Distances", new[] { "Unit_Id" });
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropIndex("dbo.Customers", new[] { "Account_Id" });
            DropIndex("dbo.CreditCards", new[] { "User_Id" });
            DropIndex("dbo.CreditCards", new[] { "Country_Id" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropIndex("dbo.CurrencyLogs", new[] { "CurrencyId" });
            DropIndex("dbo.AccountLogs", new[] { "User_Id" });
            DropIndex("dbo.AccountLogs", new[] { "Currency_Id" });
            DropIndex("dbo.AccountLogs", new[] { "Account_Id" });
            DropIndex("dbo.Currencies", new[] { "CountryId" });
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropIndex("dbo.Accounts", new[] { "Currency_Id" });
            AlterColumn("dbo.Supervisors", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Drivers", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Drivers", "NICNumber", c => c.String());
            AlterColumn("dbo.Drivers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Drivers", "Status_Id");
            DropColumn("dbo.Drivers", "ActiveVehicle_Id");
            DropColumn("dbo.Drivers", "Account_Id");
            DropColumn("dbo.AspNetUsers", "MobileNumber");
            DropColumn("dbo.Customers", "Account_Id");
            DropTable("dbo.TimeTrackers");
            DropTable("dbo.RideStatus");
            DropTable("dbo.Rides");
            DropTable("dbo.PackageVehicleTransmissions");
            DropTable("dbo.PackageVehicleModels");
            DropTable("dbo.PackageVehicleFeatures");
            DropTable("dbo.PackageVehicleBodyTypes");
            DropTable("dbo.PackageVehicleAssemblies");
            DropTable("dbo.TravelUnits");
            DropTable("dbo.PackageTravelUnits");
            DropTable("dbo.DriverLocationLogs");
            DropTable("dbo.LocationLagLons");
            DropTable("dbo.DriverLocations");
            DropTable("dbo.DriverStatus");
            DropTable("dbo.VehicleTransmissions");
            DropTable("dbo.Fares");
            DropTable("dbo.Packages");
            DropTable("dbo.VehicleMakers");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleFeatures");
            DropTable("dbo.VehicleBodyTypes");
            DropTable("dbo.VehicleAssemblies");
            DropTable("dbo.Vehicles");
            DropTable("dbo.DistanceUnits");
            DropTable("dbo.Distances");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Colors");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.CurrencyLogs");
            DropTable("dbo.AccountLogs");
            DropTable("dbo.Countries");
            DropTable("dbo.Currencies");
            DropTable("dbo.Accounts");
            CreateIndex("dbo.Supervisors", "User_Id");
            CreateIndex("dbo.Drivers", "User_Id");
            CreateIndex("dbo.Customers", "User_Id");
            AddForeignKey("dbo.Supervisors", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Drivers", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
