namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserInCreditCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditCards", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CreditCards", "User_Id");
            AddForeignKey("dbo.CreditCards", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CreditCards", new[] { "User_Id" });
            DropColumn("dbo.CreditCards", "User_Id");
        }
    }
}
