namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddURLToSubmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "URL");
        }
    }
}
