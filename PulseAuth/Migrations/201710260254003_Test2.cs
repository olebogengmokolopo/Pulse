namespace PulseAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TenancyUserRoles", "TenancyId", "dbo.Tenancies");
            AddColumn("dbo.TenancyUserRoles", "Tenancy_TenancyId", c => c.Int(nullable: false));
            CreateIndex("dbo.TenancyUserRoles", "Tenancy_TenancyId");
            AddForeignKey("dbo.TenancyUserRoles", "Tenancy_TenancyId", "dbo.Tenancies", "TenancyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TenancyUserRoles", "Tenancy_TenancyId", "dbo.Tenancies");
            DropIndex("dbo.TenancyUserRoles", new[] { "Tenancy_TenancyId" });
            DropColumn("dbo.TenancyUserRoles", "Tenancy_TenancyId");
            AddForeignKey("dbo.TenancyUserRoles", "TenancyId", "dbo.Tenancies", "TenancyId", cascadeDelete: true);
        }
    }
}
