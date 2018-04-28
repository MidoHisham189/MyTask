namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageText", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageText", c => c.String(nullable: false));
        }
    }
}
