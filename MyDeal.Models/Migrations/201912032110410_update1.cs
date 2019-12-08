namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Bids", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Bids", name: "Customer_Id", newName: "CustomerId");
            AlterColumn("dbo.Bids", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bids", "CustomerId");
            AddForeignKey("dbo.Bids", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Bids", "CustomerUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bids", "CustomerUserName", c => c.String());
            DropForeignKey("dbo.Bids", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Bids", new[] { "CustomerId" });
            AlterColumn("dbo.Bids", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Bids", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Bids", "Customer_Id");
            AddForeignKey("dbo.Bids", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
