using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMigration.Domain.core;
using TestMigration.Repository;
using TestMigration.Domain.Interface;

namespace TestMigration.Areas.MvcAppPager.Controllers
{
    public class TestPageController : Controller
    {

        private const int PageSize = 2;
        private int counts;
        private readonly ITestPageRepository _testPageRepository;

        public TestPageController(ITestPageRepository testRepository)
        {
            this._testPageRepository = testRepository;
        }
        // GET: MvcAppPager/TestPage
        public ActionResult Index(int pageIndex=0)
        {
            counts = this._testPageRepository.GetTestPageList().Count();
            var list = this._testPageRepository.GetTestPageList().OrderBy(t=>t.OrderNo).Skip(PageSize * pageIndex).Take(PageSize).ToList();
            PageOfList<TestPage> _testList = new PageOfList<TestPage>(list, pageIndex, PageSize, counts);
            return View(_testList);
        }
    }
}