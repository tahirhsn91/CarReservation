namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehiclePackage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "PackageID", "dbo.Packages");
            DropIndex("dbo.Vehicles", new[] { "PackageID" });
            AlterColumn("dbo.Vehicles", "PackageID", c => c.Int());
            CreateIndex("dbo.Vehicles", "PackageID");
            AddForeignKey("dbo.Vehicles", "PackageID", "dbo.Packages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "PackageID", "dbo.Packages");
            DropIndex("dbo.Vehicles", new[] { "PackageID" });
            AlterColumn("dbo.Vehicles", "PackageID", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "PackageID");
            AddForeignKey("dbo.Vehicles", "PackageID", "dbo.Packages", "Id", cascadeDelete: true);
        }
    }
}
