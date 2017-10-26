namespace Monitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiskSensorReadings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        Label = c.String(),
                        Volume = c.String(nullable: false),
                        AvailableSpace = c.Single(nullable: false),
                        TotalSpace = c.Single(nullable: false),
                        UsedSpace = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DiskSensorReadings");
        }
    }
}
