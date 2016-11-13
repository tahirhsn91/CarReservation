namespace CarReservation.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Currency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .Index(t => t.Currency_Id);
            
            CreateTable(
                "dbo.AccountLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        debit = c.Double(nullable: false),
                        credit = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Account_Id = c.Int(),
                        Currency_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Customers", "Account_Id", c => c.Int());
            AddColumn("dbo.Drivers", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Drivers", "Account_Id", c => c.Int());
            AddColumn("dbo.Vehicles", "Package_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Account_Id");
            CreateIndex("dbo.Drivers", "Account_Id");
            CreateIndex("dbo.Vehicles", "Package_Id");
            AddForeignKey("dbo.Customers", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Drivers", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Drivers", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Customers", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.AccountLogs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccountLogs", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.AccountLogs", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Currency_Id", "dbo.Currencies");
            DropIndex("dbo.Vehicles", new[] { "Package_Id" });
            DropIndex("dbo.Drivers", new[] { "Account_Id" });
            DropIndex("dbo.Customers", new[] { "Account_Id" });
            DropIndex("dbo.AccountLogs", new[] { "User_Id" });
            DropIndex("dbo.AccountLogs", new[] { "Currency_Id" });
            DropIndex("dbo.AccountLogs", new[] { "Account_Id" });
            DropIndex("dbo.Accounts", new[] { "Currency_Id" });
            DropColumn("dbo.Vehicles", "Package_Id");
            DropColumn("dbo.Drivers", "Account_Id");
            DropColumn("dbo.Drivers", "IsAvailable");
            DropColumn("dbo.Customers", "Account_Id");
            DropTable("dbo.AccountLogs");
            DropTable("dbo.Accounts");
        }
    }
}
