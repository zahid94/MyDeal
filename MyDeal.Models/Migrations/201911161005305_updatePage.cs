namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Pages", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Description", c => c.String());
            AlterColumn("dbo.Pages", "Name", c => c.String());
        }
    }
}
