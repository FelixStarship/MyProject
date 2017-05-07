namespace TestMigration.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Module : DbMigration
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
                        Sex = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        BizCode = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CrateId = c.Guid(),
                        Null = c.String(),
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
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Module", t => t.ParentId)
                .Index(t => t.ParentId);
            
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
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrderSort = c.Int(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        IconUrl = c.String(),
                        IsDisplay = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Module", "ParentId", "dbo.Module");
            DropForeignKey("dbo.ModuleElement", "ModuleId", "dbo.Module");
            DropIndex("dbo.ModuleElement", new[] { "ModuleId" });
            DropIndex("dbo.Module", new[] { "ParentId" });
            DropTable("dbo.Category");
            DropTable("dbo.ModuleElement");
            DropTable("dbo.Module");
            DropTable("dbo.Role");
            DropTable("dbo.User");
        }
    }
}
