namespace CraigslistMockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Active");
            DropColumn("dbo.Listings", "Active");
            DropColumn("dbo.Categories", "Active");
        }
    }
}
