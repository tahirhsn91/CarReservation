namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingUserAudit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CreatedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastModifiedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.AspNetUsers", "LastModifiedOn");
            DropColumn("dbo.AspNetUsers", "LastModifiedBy");
            DropColumn("dbo.AspNetUsers", "CreatedOn");
            DropColumn("dbo.AspNetUsers", "CreatedBy");
        }
    }
}
