namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubmissionVotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubmissionVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        SubmissionId = c.Int(nullable: false),
                        UserName = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubmissionVotes");
        }
    }
}
