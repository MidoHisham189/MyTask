namespace Tekegy_SendSms_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFKtoMobile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mobiles", "CtegoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Mobiles", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Mobiles", "Category_CategoryId");
            AddForeignKey("dbo.Mobiles", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mobiles", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Mobiles", new[] { "Category_CategoryId" });
            DropColumn("dbo.Mobiles", "Category_CategoryId");
            DropColumn("dbo.Mobiles", "CtegoryId");
        }
    }
}
