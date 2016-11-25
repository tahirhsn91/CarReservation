namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "MobileNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "MobileNumber", c => c.String(nullable: false));
        }
    }
}
