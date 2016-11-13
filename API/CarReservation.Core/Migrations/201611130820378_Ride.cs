namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ride : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Rides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalDistance = c.Double(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        RideStatus = c.String(),
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
                        Source_Id = c.Int(),
                        TotalFare_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fares", t => t.ApproximateFare_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.LocationLagLons", t => t.Destination_Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.LocationLagLons", t => t.Source_Id)
                .ForeignKey("dbo.Fares", t => t.TotalFare_Id)
                .Index(t => t.ApproximateFare_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Destination_Id)
                .Index(t => t.Driver_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.Source_Id)
                .Index(t => t.TotalFare_Id);
            
            AddColumn("dbo.TravelUnits", "Ride_Id", c => c.Int());
            CreateIndex("dbo.TravelUnits", "Ride_Id");
            AddForeignKey("dbo.TravelUnits", "Ride_Id", "dbo.Rides", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TravelUnits", "Ride_Id", "dbo.Rides");
            DropForeignKey("dbo.Rides", "TotalFare_Id", "dbo.Fares");
            DropForeignKey("dbo.Rides", "Source_Id", "dbo.LocationLagLons");
            DropForeignKey("dbo.Rides", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Rides", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Rides", "Destination_Id", "dbo.LocationLagLons");
            DropForeignKey("dbo.Rides", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rides", "ApproximateFare_Id", "dbo.Fares");
            DropIndex("dbo.Rides", new[] { "TotalFare_Id" });
            DropIndex("dbo.Rides", new[] { "Source_Id" });
            DropIndex("dbo.Rides", new[] { "Package_Id" });
            DropIndex("dbo.Rides", new[] { "Driver_Id" });
            DropIndex("dbo.Rides", new[] { "Destination_Id" });
            DropIndex("dbo.Rides", new[] { "Customer_Id" });
            DropIndex("dbo.Rides", new[] { "ApproximateFare_Id" });
            DropIndex("dbo.TravelUnits", new[] { "Ride_Id" });
            DropColumn("dbo.TravelUnits", "Ride_Id");
            DropTable("dbo.Rides");
            DropTable("dbo.LocationLagLons");
        }
    }
}
