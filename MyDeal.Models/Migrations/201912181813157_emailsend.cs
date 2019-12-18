namespace MyDeal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailsend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EmailSubject", c => c.String(maxLength: 100));
            AddColumn("dbo.Customers", "EmailBody", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "EmailBody");
            DropColumn("dbo.Customers", "EmailSubject");
        }
    }
}
