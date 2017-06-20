namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Product_Table_V2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ProductId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ProductId", c => c.String());
        }
    }
}
