namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class About : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutIamge2", c => c.String(maxLength: 255));
            AddColumn("dbo.Abouts", "AboutContent2", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
        }
    }
}
