namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bids", "BidsPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "ActualPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "CurrentPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "CurrentPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "ActualPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Bids", "BidsPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
