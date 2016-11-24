namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MobileNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MobileNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MobileNumber");
        }
    }
}
