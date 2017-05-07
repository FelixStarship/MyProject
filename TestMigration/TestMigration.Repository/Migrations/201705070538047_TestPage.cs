namespace TestMigration.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestPage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestPage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        WayFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EMS = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestPage");
        }
    }
}
