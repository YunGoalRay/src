namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Product_V3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ProductId", c => c.String(maxLength: 32));
            AlterColumn("dbo.Product", "ProductName", c => c.String(maxLength: 32));
            AlterColumn("dbo.Product", "Classify", c => c.String(maxLength: 64));
            AlterColumn("dbo.Product", "Comment", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Comment", c => c.String(maxLength: 256));
            AlterColumn("dbo.Product", "Classify", c => c.String(maxLength: 256));
            AlterColumn("dbo.Product", "ProductName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Product", "ProductId", c => c.String(maxLength: 128));
        }
    }
}
