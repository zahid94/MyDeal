namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstslider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FirstSliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FirstSliders");
        }
    }
}
