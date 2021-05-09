namespace Intelutions.Interview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeFirstName = c.String(),
                        EmployeeFamilyName = c.String(),
                        PermissionTypeId = c.Int(nullable: false),
                        PermissionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PermissionTypes", t => t.PermissionTypeId, cascadeDelete: true)
                .Index(t => t.PermissionTypeId);
            
            CreateTable(
                "dbo.PermissionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "PermissionTypeId", "dbo.PermissionTypes");
            DropIndex("dbo.Permissions", new[] { "PermissionTypeId" });
            DropTable("dbo.PermissionTypes");
            DropTable("dbo.Permissions");
        }
    }
}
