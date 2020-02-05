namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredOnSubmissionForNow : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "Title", c => c.String());
            AlterColumn("dbo.Submissions", "Content", c => c.String());
            AlterColumn("dbo.Submissions", "UserId", c => c.String());
            AlterColumn("dbo.Submissions", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Submissions", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Submissions", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Submissions", "Title", c => c.String(nullable: false));
        }
    }
}
