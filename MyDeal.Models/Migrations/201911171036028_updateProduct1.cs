namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProduct1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageName", c => c.String());
            DropColumn("dbo.Products", "ImagePathName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImagePathName", c => c.String());
            DropColumn("dbo.Products", "ImageName");
        }
    }
}
