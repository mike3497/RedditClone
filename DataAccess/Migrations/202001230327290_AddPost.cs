namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    Content = c.String(nullable: false),
                    UserId = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
