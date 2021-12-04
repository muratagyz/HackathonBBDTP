namespace BBDTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "Year", c => c.String());
            AddColumn("dbo.Regions", "Quantity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "Quantity");
            DropColumn("dbo.Regions", "Year");
        }
    }
}
