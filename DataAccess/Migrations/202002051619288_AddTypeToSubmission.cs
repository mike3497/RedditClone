namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeToSubmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "Type");
        }
    }
}
