namespace PulseAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTenancyEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tenancies",
                c => new
                    {
                        TenancyId = c.Int(nullable: false, identity: true),
                        TenancyName = c.String(nullable: false, maxLength: 100),
                        TenancyDescription = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.TenancyId);
            
            CreateTable(
                "dbo.TenancyApplicationUsers",
                c => new
                    {
                        Tenancy_TenancyId = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tenancy_TenancyId, t.ApplicationUser_Id })
                .ForeignKey("dbo.Tenancies", t => t.Tenancy_TenancyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Tenancy_TenancyId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TenancyApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TenancyApplicationUsers", "Tenancy_TenancyId", "dbo.Tenancies");
            DropIndex("dbo.TenancyApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TenancyApplicationUsers", new[] { "Tenancy_TenancyId" });
            DropTable("dbo.TenancyApplicationUsers");
            DropTable("dbo.Tenancies");
        }
    }
}
