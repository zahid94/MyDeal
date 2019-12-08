namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bids : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Bids", new[] { "CustomerId" });
            RenameColumn(table: "dbo.Bids", name: "CustomerId", newName: "Customer_Id");
            AddColumn("dbo.Bids", "CustomerUserName", c => c.String());
            AlterColumn("dbo.Bids", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Bids", "Customer_Id");
            AddForeignKey("dbo.Bids", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Bids", new[] { "Customer_Id" });
            AlterColumn("dbo.Bids", "Customer_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Bids", "CustomerUserName");
            RenameColumn(table: "dbo.Bids", name: "Customer_Id", newName: "CustomerId");
            CreateIndex("dbo.Bids", "CustomerId");
            AddForeignKey("dbo.Bids", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
