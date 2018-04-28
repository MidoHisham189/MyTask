namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMessageTitleToMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageTitle", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageTitle");
        }
    }
}
