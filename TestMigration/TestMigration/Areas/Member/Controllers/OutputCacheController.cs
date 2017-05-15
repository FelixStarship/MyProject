using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMigration.Areas.Member.Controllers
{
    public class OutputCacheController : Controller
    {
        // GET: Member/OutputCache
        [OutputCache(Duration =50,VaryByParam ="none")]
        public ActionResult Index(string name="默认")
        {
            ViewBag.Now = DateTime.Now.ToString();
            ViewData["Name"] = name;
            Response.Cache.SetOmitVaryStar(true);
            return View();
        }
    }
}