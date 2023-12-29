namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "BlogDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogDate", c => c.DateTime(nullable: false));
        }
    }
}
