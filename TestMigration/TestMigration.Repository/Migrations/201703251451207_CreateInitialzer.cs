namespace TestMigration.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInitialzer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Account = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Sex = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        BizCode = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CrateId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CascadeId = c.String(),
                        Name = c.String(),
                        Url = c.String(),
                        HotKey = c.String(),
                        IsLeaf = c.Boolean(nullable: false),
                        IsAutoExpand = c.Boolean(nullable: false),
                        IconName = c.String(),
                        Status = c.Int(nullable: false),
                        ParentName = c.String(),
                        Vector = c.String(),
                        SortNo = c.Int(nullable: false),
                        ParentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModuleElement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DomId = c.String(),
                        Name = c.String(),
                        Type = c.String(),
                        Attr = c.String(),
                        Script = c.String(),
                        Icon = c.String(),
                        Class = c.String(),
                        Remark = c.String(),
                        Sort = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModuleElement", "ModuleId", "dbo.Module");
            DropIndex("dbo.ModuleElement", new[] { "ModuleId" });
            DropTable("dbo.ModuleElement");
            DropTable("dbo.Module");
            DropTable("dbo.Role");
            DropTable("dbo.User");
        }
    }
}
