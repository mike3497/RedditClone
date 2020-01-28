namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "DatePublished", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "DatePublished");
        }
    }
}
