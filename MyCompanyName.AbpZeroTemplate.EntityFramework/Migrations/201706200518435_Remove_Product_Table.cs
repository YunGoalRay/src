namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Product_Table : DbMigration
    {
        public override void Up()
        {
            DropTable("Basic.Product",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
        
        public override void Down()
        {
            CreateTable(
                "Basic.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.String(maxLength: 32),
                        ProductName = c.String(maxLength: 32),
                        Classify = c.String(maxLength: 64),
                        Comment = c.String(maxLength: 255),
                        BusinessCategory = c.String(maxLength: 64),
                        BusinessType = c.String(maxLength: 64),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
