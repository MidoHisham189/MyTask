namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class three : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageTitle", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageTitle", c => c.String(maxLength: 11));
        }
    }
}
