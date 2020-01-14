namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GallaryImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GallaryImages", "ProductId", "dbo.Products");
            DropIndex("dbo.GallaryImages", new[] { "ProductId" });
            DropTable("dbo.GallaryImages");
        }
    }
}
