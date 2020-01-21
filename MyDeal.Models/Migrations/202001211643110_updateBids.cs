namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "BidsEndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bids", "BidsEndDate");
        }
    }
}
