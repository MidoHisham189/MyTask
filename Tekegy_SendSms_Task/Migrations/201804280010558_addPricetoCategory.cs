namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPricetoCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "price");
        }
    }
}
