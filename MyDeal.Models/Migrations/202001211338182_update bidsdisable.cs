namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebidsdisable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DisableBids", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DisableBids");
        }
    }
}
