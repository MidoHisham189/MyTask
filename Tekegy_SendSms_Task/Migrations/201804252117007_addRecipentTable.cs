namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRecipentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        RecipientId = c.Int(nullable: false, identity: true),
                        MessageStatus = c.String(nullable: false),
                        MessageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipientId)
                .ForeignKey("dbo.Messages", t => t.MessageId, cascadeDelete: true)
                .Index(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipients", "MessageId", "dbo.Messages");
            DropIndex("dbo.Recipients", new[] { "MessageId" });
            DropTable("dbo.Recipients");
        }
    }
}
