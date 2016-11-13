namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleAndPackage : DbMigration
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
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                .ForeignKey("dbo.States", t => t.State_Id)
                .ForeignKey("dbo.VehicleTransmissions", t => t.Transmission_Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .Index(t => t.Assembly_Id)
                .Index(t => t.BodyType_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Color_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Model_Id)
                .Index(t => t.State_Id)
                .Index(t => t.Transmission_Id)
                .Index(t => t.Driver_Id);
            
            CreateTable(
                "dbo.VehicleAssemblies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Package_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.VehicleBodyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Package_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.VehicleFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 250),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Vehicle_Id = c.Int(),
                        Package_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.Vehicle_Id)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Maker_Id = c.Int(nullable: false),
                        Package_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleMakers", t => t.Maker_Id, cascadeDelete: true)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.Maker_Id)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.VehicleMakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTransmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Package_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.Package_Id);
            
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
                "dbo.TravelUnits",
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.Package_Id);
            
            AddColumn("dbo.Drivers", "ActiveVehicle_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Drivers", "Address", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Drivers", "NICNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Drivers", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Supervisors", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Customers", "User_Id");
            CreateIndex("dbo.Drivers", "ActiveVehicle_Id");
            CreateIndex("dbo.Drivers", "User_Id");
            CreateIndex("dbo.Supervisors", "User_Id");
            AddForeignKey("dbo.Drivers", "ActiveVehicle_Id", "dbo.Vehicles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Drivers", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Supervisors", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supervisors", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Drivers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TravelUnits", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.TravelUnits", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.VehicleTransmissions", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Packages", "StartFare_Id", "dbo.Fares");
            DropForeignKey("dbo.VehicleModels", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.VehicleFeatures", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.VehicleBodyTypes", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.VehicleAssemblies", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Fares", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Vehicles", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "ActiveVehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Transmission_Id", "dbo.VehicleTransmissions");
            DropForeignKey("dbo.Vehicles", "State_Id", "dbo.States");
            DropForeignKey("dbo.Vehicles", "Model_Id", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "Maker_Id", "dbo.VehicleMakers");
            DropForeignKey("dbo.VehicleFeatures", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Vehicles", "Color_Id", "dbo.Colors");
            DropForeignKey("dbo.Vehicles", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Vehicles", "BodyType_Id", "dbo.VehicleBodyTypes");
            DropForeignKey("dbo.Vehicles", "Assembly_Id", "dbo.VehicleAssemblies");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropIndex("dbo.Supervisors", new[] { "User_Id" });
            DropIndex("dbo.TravelUnits", new[] { "Package_Id" });
            DropIndex("dbo.TravelUnits", new[] { "Currency_Id" });
            DropIndex("dbo.Packages", new[] { "StartFare_Id" });
            DropIndex("dbo.Fares", new[] { "Currency_Id" });
            DropIndex("dbo.VehicleTransmissions", new[] { "Package_Id" });
            DropIndex("dbo.VehicleModels", new[] { "Package_Id" });
            DropIndex("dbo.VehicleModels", new[] { "Maker_Id" });
            DropIndex("dbo.VehicleFeatures", new[] { "Package_Id" });
            DropIndex("dbo.VehicleFeatures", new[] { "Vehicle_Id" });
            DropIndex("dbo.VehicleBodyTypes", new[] { "Package_Id" });
            DropIndex("dbo.VehicleAssemblies", new[] { "Package_Id" });
            DropIndex("dbo.Vehicles", new[] { "Driver_Id" });
            DropIndex("dbo.Vehicles", new[] { "Transmission_Id" });
            DropIndex("dbo.Vehicles", new[] { "State_Id" });
            DropIndex("dbo.Vehicles", new[] { "Model_Id" });
            DropIndex("dbo.Vehicles", new[] { "Country_Id" });
            DropIndex("dbo.Vehicles", new[] { "Color_Id" });
            DropIndex("dbo.Vehicles", new[] { "City_Id" });
            DropIndex("dbo.Vehicles", new[] { "BodyType_Id" });
            DropIndex("dbo.Vehicles", new[] { "Assembly_Id" });
            DropIndex("dbo.Drivers", new[] { "User_Id" });
            DropIndex("dbo.Drivers", new[] { "ActiveVehicle_Id" });
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropIndex("dbo.States", new[] { "Country_Id" });
            DropIndex("dbo.Cities", new[] { "State_Id" });
            AlterColumn("dbo.Supervisors", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Drivers", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Drivers", "NICNumber", c => c.String());
            AlterColumn("dbo.Drivers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Drivers", "ActiveVehicle_Id");
            DropTable("dbo.TravelUnits");
            DropTable("dbo.Packages");
            DropTable("dbo.Fares");
            DropTable("dbo.VehicleTransmissions");
            DropTable("dbo.VehicleMakers");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleFeatures");
            DropTable("dbo.VehicleBodyTypes");
            DropTable("dbo.VehicleAssemblies");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Currencies");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.Colors");
            DropTable("dbo.Cities");
            CreateIndex("dbo.Supervisors", "User_Id");
            CreateIndex("dbo.Drivers", "User_Id");
            CreateIndex("dbo.Customers", "User_Id");
            AddForeignKey("dbo.Supervisors", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Drivers", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
