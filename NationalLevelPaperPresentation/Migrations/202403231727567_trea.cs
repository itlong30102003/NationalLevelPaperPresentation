namespace NationalLevelPaperPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trea : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participant", "phone", c => c.String(maxLength: 50));
            AlterColumn("dbo.Participant", "Description", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participant", "Description", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Participant", "phone", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
