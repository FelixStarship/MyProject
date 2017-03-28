namespace TestMigration.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCategory : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Category");
        }
    }
}
