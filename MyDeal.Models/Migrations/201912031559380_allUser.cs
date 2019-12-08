namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        BidsPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BidsTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        PassWord = c.String(nullable: false),
                        ConfirmPassWord = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        TotalBids = c.Int(nullable: false),
                        ActualPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BidEndDate = c.DateTime(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomePageSliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        phone = c.Int(nullable: false),
                        address = c.String(),
                        password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Bids", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Bids", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Bids", new[] { "ProductId" });
            DropIndex("dbo.Bids", new[] { "CustomerId" });
            DropTable("dbo.AdminRegistrations");
            DropTable("dbo.Pages");
            DropTable("dbo.HomePageSliders");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Bids");
        }
    }
}
