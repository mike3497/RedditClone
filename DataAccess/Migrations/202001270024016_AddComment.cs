namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        PostId = c.Int(nullable: false),
                        ParentCommentId = c.Int(nullable: false),
                        UserId = c.String(),
                        UserName = c.String(),
                        UpVotes = c.Int(nullable: false),
                        DownVotes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
