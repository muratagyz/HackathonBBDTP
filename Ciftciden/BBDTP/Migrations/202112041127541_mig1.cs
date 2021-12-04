namespace BBDTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                    })
                .PrimaryKey(t => t.RegionId);
            
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        FarmdId = c.Int(nullable: false, identity: true),
                        FarmdName = c.String(),
                        FarmPassword = c.String(),
                    })
                .PrimaryKey(t => t.FarmdId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductStock = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        FarmId = c.Int(nullable: false),
                        Farm_FarmdId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Farms", t => t.Farm_FarmdId)
                .Index(t => t.CategoryId)
                .Index(t => t.CityId)
                .Index(t => t.Farm_FarmdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Farm_FarmdId", "dbo.Farms");
            DropForeignKey("dbo.Products", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Cities", "RegionId", "dbo.Regions");
            DropIndex("dbo.Products", new[] { "Farm_FarmdId" });
            DropIndex("dbo.Products", new[] { "CityId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Cities", new[] { "RegionId" });
            DropTable("dbo.Products");
            DropTable("dbo.Farms");
            DropTable("dbo.Regions");
            DropTable("dbo.Cities");
            DropTable("dbo.Categories");
        }
    }
}
