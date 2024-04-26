namespace NationalLevelPaperPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afffffffa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        activity_id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 100, unicode: false),
                        date = c.DateTime(storeType: "date"),
                        time = c.Time(precision: 7),
                        fee = c.Double(),
                        eligibility = c.String(maxLength: 100, unicode: false),
                        prize_details = c.String(unicode: false, storeType: "text"),
                        address = c.String(unicode: false, storeType: "text"),
                        terms_and_conditions = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.activity_id);
            
            CreateTable(
                "dbo.Participant",
                c => new
                    {
                        participant_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                        email = c.String(nullable: false, maxLength: 50, unicode: false),
                        phone = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        payment_status = c.Boolean(),
                    })
                .PrimaryKey(t => t.participant_id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50, unicode: false),
                        password = c.String(nullable: false, maxLength: 255, unicode: false),
                        email = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 255, unicode: false),
                        Password = c.String(nullable: false, maxLength: 255, unicode: false),
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.User_Participant",
                c => new
                    {
                        participant_id = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.participant_id, t.user_id })
                .ForeignKey("dbo.Participant", t => t.participant_id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.user_id, cascadeDelete: true)
                .Index(t => t.participant_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Participant_Activity",
                c => new
                    {
                        activity_id = c.Int(nullable: false),
                        participant_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.activity_id, t.participant_id })
                .ForeignKey("dbo.Activity", t => t.activity_id, cascadeDelete: true)
                .ForeignKey("dbo.Participant", t => t.participant_id, cascadeDelete: true)
                .Index(t => t.activity_id)
                .Index(t => t.participant_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participant_Activity", "participant_id", "dbo.Participant");
            DropForeignKey("dbo.Participant_Activity", "activity_id", "dbo.Activity");
            DropForeignKey("dbo.User_Participant", "user_id", "dbo.User");
            DropForeignKey("dbo.User_Participant", "participant_id", "dbo.Participant");
            DropIndex("dbo.Participant_Activity", new[] { "participant_id" });
            DropIndex("dbo.Participant_Activity", new[] { "activity_id" });
            DropIndex("dbo.User_Participant", new[] { "user_id" });
            DropIndex("dbo.User_Participant", new[] { "participant_id" });
            DropTable("dbo.Participant_Activity");
            DropTable("dbo.User_Participant");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Admin");
            DropTable("dbo.User");
            DropTable("dbo.Participant");
            DropTable("dbo.Activity");
        }
    }
}
