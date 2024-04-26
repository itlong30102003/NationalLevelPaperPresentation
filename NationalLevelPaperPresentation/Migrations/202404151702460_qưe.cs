namespace NationalLevelPaperPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qưe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participant", "name", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Participant", "email", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participant", "email", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Participant", "name", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
