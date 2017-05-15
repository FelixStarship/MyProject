using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMigration.Models;

namespace TestMigration.Areas.CSRF.Controllers
{
    public class CsrfController : Controller
    {
        // GET: CSRF/Csrf
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [MyValidateAntiForgeryToken]
        public ActionResult SaveCsrf(string orderTitle)
        {
            return View();
        }
    }
}