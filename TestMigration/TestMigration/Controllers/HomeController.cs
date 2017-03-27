using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMigration.Repository;
using TestMigration.Domain.Interface;

namespace TestMigration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        public HomeController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public ActionResult Index()
        {
            this._userRepository.LoadUsers(1,2);
            this._userRepository.LoadInOrgs(System.Guid.NewGuid());
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