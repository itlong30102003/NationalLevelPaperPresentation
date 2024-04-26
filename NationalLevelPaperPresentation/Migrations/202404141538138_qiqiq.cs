namespace NationalLevelPaperPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qiqiq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activity", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activity", "Image", c => c.String(maxLength: 1000));
        }
    }
}
