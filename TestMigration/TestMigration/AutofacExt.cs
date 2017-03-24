using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using TestMigration.Repository;
using TestMigration.Domain.Interface;

namespace TestMigration
{
    public static class AutofacExt
    {
        private static IContainer _container;
        public static void InitAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
        }
    }
}