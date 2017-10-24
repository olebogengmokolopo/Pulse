namespace PulseAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustedUserRoleToIncludeTenancy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TenancyApplicationUsers", "Tenancy_TenancyId", "dbo.Tenancies");
            DropForeignKey("dbo.TenancyApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TenancyApplicationUsers", new[] { "Tenancy_TenancyId" });
            DropIndex("dbo.TenancyApplicationUsers", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.TenancyUserRoles",
                c => new
                    {
                        ApplicationUserId = c.Int(nullable: false),
                        TenancyId = c.Int(nullable: false),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.TenancyId })
                .ForeignKey("dbo.AspNetRoles", t => t.Role_Id)
                .ForeignKey("dbo.Tenancies", t => t.TenancyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.TenancyId)
                .Index(t => t.Role_Id);
            
            DropTable("dbo.TenancyApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TenancyApplicationUsers",
                c => new
                    {
                        Tenancy_TenancyId = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tenancy_TenancyId, t.ApplicationUser_Id });
            
            DropForeignKey("dbo.TenancyUserRoles", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TenancyUserRoles", "TenancyId", "dbo.Tenancies");
            DropForeignKey("dbo.TenancyUserRoles", "Role_Id", "dbo.AspNetRoles");
            DropIndex("dbo.TenancyUserRoles", new[] { "Role_Id" });
            DropIndex("dbo.TenancyUserRoles", new[] { "TenancyId" });
            DropIndex("dbo.TenancyUserRoles", new[] { "ApplicationUserId" });
            DropTable("dbo.TenancyUserRoles");
            CreateIndex("dbo.TenancyApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.TenancyApplicationUsers", "Tenancy_TenancyId");
            AddForeignKey("dbo.TenancyApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TenancyApplicationUsers", "Tenancy_TenancyId", "dbo.Tenancies", "TenancyId", cascadeDelete: true);
        }
    }
}
