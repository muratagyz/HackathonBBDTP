namespace BBDTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rains",
                c => new
                    {
                        RainId = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RainId)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            DropColumn("dbo.Regions", "Year");
            DropColumn("dbo.Regions", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regions", "Quantity", c => c.String());
            AddColumn("dbo.Regions", "Year", c => c.String());
            DropForeignKey("dbo.Rains", "RegionId", "dbo.Regions");
            DropIndex("dbo.Rains", new[] { "RegionId" });
            DropTable("dbo.Rains");
        }
    }
}
