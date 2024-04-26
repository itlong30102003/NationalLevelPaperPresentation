namespace NationalLevelPaperPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qweqeq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "Image", c => c.String(maxLength: 1000));
            AddColumn("dbo.Activity", "Description", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activity", "Description");
            DropColumn("dbo.Activity", "Image");
        }
    }
}
