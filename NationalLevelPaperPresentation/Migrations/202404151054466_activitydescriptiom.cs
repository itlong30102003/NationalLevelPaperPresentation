namespace NationalLevelPaperPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activitydescriptiom : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activity", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activity", "Description", c => c.String(maxLength: 255));
        }
    }
}
