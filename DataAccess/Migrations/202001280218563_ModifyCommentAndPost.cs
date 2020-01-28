namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCommentAndPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "TimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "TimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.Comments", "DatePublished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "DatePublished", c => c.DateTime(nullable: false));
            DropColumn("dbo.Posts", "TimeStamp");
            DropColumn("dbo.Comments", "TimeStamp");
        }
    }
}
