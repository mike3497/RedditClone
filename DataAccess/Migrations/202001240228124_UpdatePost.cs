namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Posts", "UpVotes", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "DownVotes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "DownVotes");
            DropColumn("dbo.Posts", "UpVotes");
            DropColumn("dbo.Posts", "UserName");
        }
    }
}
