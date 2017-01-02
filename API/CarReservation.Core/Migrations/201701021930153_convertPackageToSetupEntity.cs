namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertPackageToSetupEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packages", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Packages", "Code", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packages", "Code");
            DropColumn("dbo.Packages", "Name");
        }
    }
}
