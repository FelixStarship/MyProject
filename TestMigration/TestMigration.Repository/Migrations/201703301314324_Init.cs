namespace TestMigration.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Module", "ParentId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Module", "ParentId", c => c.Guid(nullable: false));
        }
    }
}
