namespace TestMigration.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestMigration.Repository.TestMigrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestMigration.Repository.TestMigrationContext context)
        {



            //初始化标示种子
            context.Database.ExecuteSqlCommand(@"DBCC CHECKIDENT ('[dbo].[User]', RESEED, 100000);");
            context.Database.ExecuteSqlCommand(@"insert into [dbo].[User] values('1','1','1',1,1,1,'1','2017-03-19','00000000000000',0)");



            

        }
    }
}
