namespace TestMigration.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Null", c => c.String());
            AlterColumn("dbo.User", "Sex", c => c.Boolean(nullable: false));
            AlterColumn("dbo.User", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Sex", c => c.Int(nullable: false));
            DropColumn("dbo.User", "Null");
        }
    }
}
