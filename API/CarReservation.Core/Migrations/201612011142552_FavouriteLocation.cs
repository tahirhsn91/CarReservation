namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavouriteLocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavouriteLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        LocationId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LocationLagLons", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.LocationId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavouriteLocations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavouriteLocations", "LocationId", "dbo.LocationLagLons");
            DropIndex("dbo.FavouriteLocations", new[] { "UserId" });
            DropIndex("dbo.FavouriteLocations", new[] { "LocationId" });
            DropTable("dbo.FavouriteLocations");
        }
    }
}
