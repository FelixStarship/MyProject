using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using TestMigration.Repository;
using TestMigration.Domain.Interface;
using System.Web.Mvc;


namespace TestMigration
{
    public static class AutofacExt
    {
        private static IContainer _container;
        public static void InitAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TestMigrationContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ModuleRepository>().As<IModuleRepository>().InstancePerLifetimeScope();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}