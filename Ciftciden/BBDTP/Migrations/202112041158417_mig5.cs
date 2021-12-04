namespace BBDTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rains", "RainYear", c => c.String());
            AddColumn("dbo.Rains", "RainQuantity", c => c.String());
            DropColumn("dbo.Rains", "RainName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rains", "RainName", c => c.String());
            DropColumn("dbo.Rains", "RainQuantity");
            DropColumn("dbo.Rains", "RainYear");
        }
    }
}
