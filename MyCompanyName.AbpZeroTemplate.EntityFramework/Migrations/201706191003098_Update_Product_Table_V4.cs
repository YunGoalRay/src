namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Product_Table_V4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Product");
            AlterTableAnnotations(
                "dbo.Product",
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Product_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Product", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "DeleterUserId", c => c.Long());
            AddColumn("dbo.Product", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.Product", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.Product", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.Product", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Product", "CreatorUserId", c => c.Long());
            AlterColumn("dbo.Product", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Product", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Product");
            AlterColumn("dbo.Product", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Product", "CreatorUserId");
            DropColumn("dbo.Product", "CreationTime");
            DropColumn("dbo.Product", "LastModifierUserId");
            DropColumn("dbo.Product", "LastModificationTime");
            DropColumn("dbo.Product", "DeletionTime");
            DropColumn("dbo.Product", "DeleterUserId");
            DropColumn("dbo.Product", "IsDeleted");
            AlterTableAnnotations(
                "dbo.Product",
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Product_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AddPrimaryKey("dbo.Product", "Id");
        }
    }
}
