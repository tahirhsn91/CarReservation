namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VehicleModels", name: "Maker_Id", newName: "VehicleMakerId");
            RenameIndex(table: "dbo.VehicleModels", name: "IX_Maker_Id", newName: "IX_VehicleMakerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.VehicleModels", name: "IX_VehicleMakerId", newName: "IX_Maker_Id");
            RenameColumn(table: "dbo.VehicleModels", name: "VehicleMakerId", newName: "Maker_Id");
        }
    }
}
