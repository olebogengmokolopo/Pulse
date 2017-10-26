namespace PulseAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TenancyUserRoles", "Role_Id", "dbo.AspNetRoles");
            DropIndex("dbo.TenancyUserRoles", new[] { "Role_Id" });
            AlterColumn("dbo.TenancyUserRoles", "Role_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.TenancyUserRoles", "Role_Id");
            AddForeignKey("dbo.TenancyUserRoles", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TenancyUserRoles", "Role_Id", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TenancyUserRoles", "Role_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.TenancyUserRoles", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.TenancyUserRoles", new[] { "Role_Id" });
            AlterColumn("dbo.TenancyUserRoles", "Role_Id", c => c.Int());
            CreateIndex("dbo.TenancyUserRoles", "Role_Id");
            AddForeignKey("dbo.TenancyUserRoles", "Role_Id", "dbo.AspNetRoles", "Id");
        }
    }
}
