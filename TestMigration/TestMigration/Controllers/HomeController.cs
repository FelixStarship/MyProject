using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMigration.Repository;
namespace TestMigration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (TestMigrationContext context = new TestMigrationContext())
            {
                //context.Database.Initialize(true);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}