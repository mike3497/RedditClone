namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifySubmission : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Submissions", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Submissions", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "UserName", c => c.String());
            AlterColumn("dbo.Submissions", "UserId", c => c.String());
            AlterColumn("dbo.Submissions", "Title", c => c.String());
        }
    }
}
