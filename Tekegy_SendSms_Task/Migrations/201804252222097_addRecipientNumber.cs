namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRecipientNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipients", "RecipientNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipients", "RecipientNumber");
        }
    }
}
