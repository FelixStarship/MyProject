namespace TestMigration.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        OrderTitle = c.String(),
                        Customer = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        EmployeeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeOrder",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.OrderId })
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeOrder", "OrderId", "dbo.Order");
            DropForeignKey("dbo.EmployeeOrder", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.EmployeeOrder", new[] { "OrderId" });
            DropIndex("dbo.EmployeeOrder", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeOrder");
            DropTable("dbo.Employee");
            DropTable("dbo.Order");
        }
    }
}
