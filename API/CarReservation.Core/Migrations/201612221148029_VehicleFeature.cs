namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleFeature : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleFeatures", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Assembly_Id", "dbo.VehicleAssemblies");
            DropForeignKey("dbo.Vehicles", "BodyType_Id", "dbo.VehicleBodyTypes");
            DropForeignKey("dbo.Vehicles", "Color_Id", "dbo.Colors");
            DropForeignKey("dbo.Vehicles", "Model_Id", "dbo.VehicleModels");
            DropForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Vehicles", "Transmission_Id", "dbo.VehicleTransmissions");
            DropForeignKey("dbo.Packages", "StartFare_Id", "dbo.Fares");
            DropForeignKey("dbo.Fares", "Currency_Id", "dbo.Currencies");
            DropIndex("dbo.Vehicles", new[] { "Assembly_Id" });
            DropIndex("dbo.Vehicles", new[] { "BodyType_Id" });
            DropIndex("dbo.Vehicles", new[] { "City_Id" });
            DropIndex("dbo.Vehicles", new[] { "Color_Id" });
            DropIndex("dbo.Vehicles", new[] { "Country_Id" });
            DropIndex("dbo.Vehicles", new[] { "Model_Id" });
            DropIndex("dbo.Vehicles", new[] { "Package_Id" });
            DropIndex("dbo.Vehicles", new[] { "State_Id" });
            DropIndex("dbo.Vehicles", new[] { "Transmission_Id" });
            DropIndex("dbo.VehicleFeatures", new[] { "Vehicle_Id" });
            DropIndex("dbo.Packages", new[] { "StartFare_Id" });
            DropIndex("dbo.Fares", new[] { "Currency_Id" });
            RenameColumn(table: "dbo.Vehicles", name: "Assembly_Id", newName: "AssemblyId");
            RenameColumn(table: "dbo.Vehicles", name: "BodyType_Id", newName: "BodyTypeId");
            RenameColumn(table: "dbo.Vehicles", name: "City_Id", newName: "CityId");
            RenameColumn(table: "dbo.Vehicles", name: "Color_Id", newName: "ColorId");
            RenameColumn(table: "dbo.Vehicles", name: "Country_Id", newName: "CountryId");
            RenameColumn(table: "dbo.Vehicles", name: "Model_Id", newName: "ModelId");
            RenameColumn(table: "dbo.Vehicles", name: "Package_Id", newName: "PackageID");
            RenameColumn(table: "dbo.Vehicles", name: "State_Id", newName: "StateId");
            RenameColumn(table: "dbo.Vehicles", name: "Transmission_Id", newName: "TransmissionId");
            RenameColumn(table: "dbo.Packages", name: "StartFare_Id", newName: "StartFareId");
            RenameColumn(table: "dbo.Fares", name: "Currency_Id", newName: "CurrencyId");
            CreateTable(
                "dbo.VehicleVehicleFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        VehicleFeatureId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleFeatures", t => t.VehicleFeatureId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.VehicleFeatureId);
            
            AlterColumn("dbo.Vehicles", "AssemblyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "BodyTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "ColorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "ModelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "PackageID", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "StateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "TransmissionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Packages", "StartFareId", c => c.Int(nullable: false));
            AlterColumn("dbo.Fares", "CurrencyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "CountryId");
            CreateIndex("dbo.Vehicles", "StateId");
            CreateIndex("dbo.Vehicles", "CityId");
            CreateIndex("dbo.Vehicles", "ColorId");
            CreateIndex("dbo.Vehicles", "BodyTypeId");
            CreateIndex("dbo.Vehicles", "AssemblyId");
            CreateIndex("dbo.Vehicles", "TransmissionId");
            CreateIndex("dbo.Vehicles", "ModelId");
            CreateIndex("dbo.Vehicles", "PackageID");
            CreateIndex("dbo.Packages", "StartFareId");
            CreateIndex("dbo.Fares", "CurrencyId");
            AddForeignKey("dbo.Vehicles", "AssemblyId", "dbo.VehicleAssemblies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "BodyTypeId", "dbo.VehicleBodyTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "ColorId", "dbo.Colors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "ModelId", "dbo.VehicleModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "PackageID", "dbo.Packages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "TransmissionId", "dbo.VehicleTransmissions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Packages", "StartFareId", "dbo.Fares", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Fares", "CurrencyId", "dbo.Currencies", "Id", cascadeDelete: true);
            DropColumn("dbo.VehicleFeatures", "Vehicle_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleFeatures", "Vehicle_Id", c => c.Int());
            DropForeignKey("dbo.Fares", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Packages", "StartFareId", "dbo.Fares");
            DropForeignKey("dbo.Vehicles", "TransmissionId", "dbo.VehicleTransmissions");
            DropForeignKey("dbo.Vehicles", "PackageID", "dbo.Packages");
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.Vehicles", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Vehicles", "BodyTypeId", "dbo.VehicleBodyTypes");
            DropForeignKey("dbo.Vehicles", "AssemblyId", "dbo.VehicleAssemblies");
            DropForeignKey("dbo.VehicleVehicleFeatures", "VehicleFeatureId", "dbo.VehicleFeatures");
            DropForeignKey("dbo.VehicleVehicleFeatures", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.VehicleVehicleFeatures", new[] { "VehicleFeatureId" });
            DropIndex("dbo.VehicleVehicleFeatures", new[] { "VehicleId" });
            DropIndex("dbo.Fares", new[] { "CurrencyId" });
            DropIndex("dbo.Packages", new[] { "StartFareId" });
            DropIndex("dbo.Vehicles", new[] { "PackageID" });
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
            DropIndex("dbo.Vehicles", new[] { "TransmissionId" });
            DropIndex("dbo.Vehicles", new[] { "AssemblyId" });
            DropIndex("dbo.Vehicles", new[] { "BodyTypeId" });
            DropIndex("dbo.Vehicles", new[] { "ColorId" });
            DropIndex("dbo.Vehicles", new[] { "CityId" });
            DropIndex("dbo.Vehicles", new[] { "StateId" });
            DropIndex("dbo.Vehicles", new[] { "CountryId" });
            AlterColumn("dbo.Fares", "CurrencyId", c => c.Int());
            AlterColumn("dbo.Packages", "StartFareId", c => c.Int());
            AlterColumn("dbo.Vehicles", "TransmissionId", c => c.Int());
            AlterColumn("dbo.Vehicles", "StateId", c => c.Int());
            AlterColumn("dbo.Vehicles", "PackageID", c => c.Int());
            AlterColumn("dbo.Vehicles", "ModelId", c => c.Int());
            AlterColumn("dbo.Vehicles", "CountryId", c => c.Int());
            AlterColumn("dbo.Vehicles", "ColorId", c => c.Int());
            AlterColumn("dbo.Vehicles", "CityId", c => c.Int());
            AlterColumn("dbo.Vehicles", "BodyTypeId", c => c.Int());
            AlterColumn("dbo.Vehicles", "AssemblyId", c => c.Int());
            DropTable("dbo.VehicleVehicleFeatures");
            RenameColumn(table: "dbo.Fares", name: "CurrencyId", newName: "Currency_Id");
            RenameColumn(table: "dbo.Packages", name: "StartFareId", newName: "StartFare_Id");
            RenameColumn(table: "dbo.Vehicles", name: "TransmissionId", newName: "Transmission_Id");
            RenameColumn(table: "dbo.Vehicles", name: "StateId", newName: "State_Id");
            RenameColumn(table: "dbo.Vehicles", name: "PackageID", newName: "Package_Id");
            RenameColumn(table: "dbo.Vehicles", name: "ModelId", newName: "Model_Id");
            RenameColumn(table: "dbo.Vehicles", name: "CountryId", newName: "Country_Id");
            RenameColumn(table: "dbo.Vehicles", name: "ColorId", newName: "Color_Id");
            RenameColumn(table: "dbo.Vehicles", name: "CityId", newName: "City_Id");
            RenameColumn(table: "dbo.Vehicles", name: "BodyTypeId", newName: "BodyType_Id");
            RenameColumn(table: "dbo.Vehicles", name: "AssemblyId", newName: "Assembly_Id");
            CreateIndex("dbo.Fares", "Currency_Id");
            CreateIndex("dbo.Packages", "StartFare_Id");
            CreateIndex("dbo.VehicleFeatures", "Vehicle_Id");
            CreateIndex("dbo.Vehicles", "Transmission_Id");
            CreateIndex("dbo.Vehicles", "State_Id");
            CreateIndex("dbo.Vehicles", "Package_Id");
            CreateIndex("dbo.Vehicles", "Model_Id");
            CreateIndex("dbo.Vehicles", "Country_Id");
            CreateIndex("dbo.Vehicles", "Color_Id");
            CreateIndex("dbo.Vehicles", "City_Id");
            CreateIndex("dbo.Vehicles", "BodyType_Id");
            CreateIndex("dbo.Vehicles", "Assembly_Id");
            AddForeignKey("dbo.Fares", "Currency_Id", "dbo.Currencies", "Id");
            AddForeignKey("dbo.Packages", "StartFare_Id", "dbo.Fares", "Id");
            AddForeignKey("dbo.Vehicles", "Transmission_Id", "dbo.VehicleTransmissions", "Id");
            AddForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages", "Id");
            AddForeignKey("dbo.Vehicles", "Model_Id", "dbo.VehicleModels", "Id");
            AddForeignKey("dbo.Vehicles", "Color_Id", "dbo.Colors", "Id");
            AddForeignKey("dbo.Vehicles", "BodyType_Id", "dbo.VehicleBodyTypes", "Id");
            AddForeignKey("dbo.Vehicles", "Assembly_Id", "dbo.VehicleAssemblies", "Id");
            AddForeignKey("dbo.VehicleFeatures", "Vehicle_Id", "dbo.Vehicles", "Id");
        }
    }
}
