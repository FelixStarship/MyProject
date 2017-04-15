using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using TestMigration.Repository;
using TestMigration.AutoMapper;

namespace TestMigration
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AutofacExt.InitAutofac();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //using (TestMigrationContext context = new TestMigrationContext())
            //{
            //    //context.Database.Initialize(true);
            //}
            AutoMapperStartupTask.Configure();
        }
    }
}
