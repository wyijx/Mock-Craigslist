namespace CraigslistMockUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Picture = c.String(),
                        Category_Id = c.Int(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listings", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Listings", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Listings", new[] { "Owner_Id" });
            DropIndex("dbo.Listings", new[] { "Category_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Listings");
            DropTable("dbo.Categories");
        }
    }
}
