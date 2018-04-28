namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageTitle", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageTitle", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
