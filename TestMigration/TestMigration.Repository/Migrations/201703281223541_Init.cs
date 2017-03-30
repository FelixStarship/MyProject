namespace TestMigration.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.User", "Null", c => c.String());
            AlterColumn("dbo.User", "Sex", c => c.Boolean(nullable: false));
            AlterColumn("dbo.User", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Sex", c => c.Int(nullable: false));
            DropColumn("dbo.User", "Null");
            DropTable("dbo.Category");
        }
    }
}
