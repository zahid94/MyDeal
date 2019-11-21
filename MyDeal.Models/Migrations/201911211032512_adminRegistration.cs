namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminRegistration : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.AdminRegistrations");
        }
    }
}
