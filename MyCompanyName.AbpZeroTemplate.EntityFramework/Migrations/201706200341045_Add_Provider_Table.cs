namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Provider_Table : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Product", newSchema: "Basic");
            CreateTable(
                "Basic.Provider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderName = c.String(maxLength: 64),
                        ProviderId = c.String(maxLength: 16),
                        ShortName = c.String(maxLength: 16),
                        ProviderType = c.String(maxLength: 16),
                        Address = c.String(maxLength: 128),
                        BusinessPhone = c.String(maxLength: 16),
                        BusinessContact = c.String(maxLength: 16),
                        Owner = c.String(maxLength: 16),
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
                    { "DynamicFilter_Provider_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Basic.Provider",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Provider_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            MoveTable(name: "Basic.Product", newSchema: "dbo");
        }
    }
}
