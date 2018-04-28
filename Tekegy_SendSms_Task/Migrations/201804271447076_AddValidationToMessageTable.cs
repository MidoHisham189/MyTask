namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToMessageTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageTitle", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Messages", "MessageText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageText", c => c.String());
            AlterColumn("dbo.Messages", "MessageTitle", c => c.String());
        }
    }
}
