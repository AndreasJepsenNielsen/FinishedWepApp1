namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneToApplicationUser2 : DbMigration
    {
        
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers","Phone");
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 75));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
