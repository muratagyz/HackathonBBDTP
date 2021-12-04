namespace BBDTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rains", "RainQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rains", "RainQuantity", c => c.String());
        }
    }
}
