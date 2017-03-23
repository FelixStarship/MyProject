using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Repository.Mapping;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestMigration.Repository
{

    /*
    策略一：数据库不存在时重新创建数据库
    
    Database.SetInitializer<testContext>(new CreateDatabaseIfNotExists<testContext>());

     策略二：每次启动应用程序时创建数据库
    Database.SetInitializer<testContext>(new DropCreateDatabaseAlways<testContext>());

    策略三：模型更改时重新创建数据库
    Database.SetInitializer<testContext>(new DropCreateDatabaseIfModelChanges<testContext>());

    策略四：从不创建数据库
    Database.SetInitializer<testContext>(null);
    */
    public class TestMigrationContext:DbContext
    {
        static TestMigrationContext()
        {
            Database.SetInitializer<TestMigrationContext>(null);
            //Database.SetInitializer<TestMigrationContext>(new CreateDatabaseIfNotExists<TestMigrationContext>());
        }

        public TestMigrationContext() : base("name=TestMigration")
        {
            //Database.SetInitializer<TestMigrationContext>(new DropCreateDatabaseAlways<TestMigrationContext>());
            //Database.SetInitializer<TestMigration.Repository.TestMigrationContext>(new MigrateDatabaseToLatestVersion<TestMigration.Repository.TestMigrationContext, Migrations.DbMigrationDatabaseInitializer>());
        }

        public TestMigrationContext(string nameOrConnectionString) : base(nameOrConnectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();   //剔除表名默认的复数形式
            modelBuilder.Configurations.Add(new UserMap());   //添加Fluent API配置
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new ModuleElementMap());
        }
    }
}
