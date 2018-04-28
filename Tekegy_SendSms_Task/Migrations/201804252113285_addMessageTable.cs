namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMessageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        SentTime = c.DateTime(nullable: false),
                        MessageText = c.String(nullable: false),
                        MessageCost = c.Double(nullable: false),
                        MobileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Mobiles", t => t.MobileId, cascadeDelete: true)
                .Index(t => t.MobileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "MobileId", "dbo.Mobiles");
            DropIndex("dbo.Messages", new[] { "MobileId" });
            DropTable("dbo.Messages");
        }
    }
}
