namespace BBDTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rains", "RainName", c => c.String());
            DropColumn("dbo.Rains", "RegionName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rains", "RegionName", c => c.String());
            DropColumn("dbo.Rains", "RainName");
        }
    }
}
