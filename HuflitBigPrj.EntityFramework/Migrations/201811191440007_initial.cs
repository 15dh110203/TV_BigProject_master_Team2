namespace HuflitBigPrj.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.Int(nullable: false, identity: true),
                        CustName = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        Status = c.String(maxLength: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Customer_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Customers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "DeleterUserId", c => c.Long());
            AddColumn("dbo.Customers", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.Customers", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.Customers", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.Customers", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "CreatorUserId", c => c.Long());
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.Customers", "CreatorUserId");
            DropColumn("dbo.Customers", "CreationTime");
            DropColumn("dbo.Customers", "LastModifierUserId");
            DropColumn("dbo.Customers", "LastModificationTime");
            DropColumn("dbo.Customers", "DeletionTime");
            DropColumn("dbo.Customers", "DeleterUserId");
            DropColumn("dbo.Customers", "IsDeleted");
            AlterTableAnnotations(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.Int(nullable: false, identity: true),
                        CustName = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        Status = c.String(maxLength: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Customer_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
