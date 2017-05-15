using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMigration.Domain.Interface;
using Newtonsoft.Json;

namespace TestMigration.Areas.Member.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly IDbContext _dbContext;
        public CustomerController(IUserRepository userRepository,
            IDbContext dbContext)
        {
            this._userRepository = userRepository;
            this._dbContext = dbContext;
        }
        public ActionResult Index()
        {
            return View("CustomerList");
        }
        // GET: Member/Customer
        public ActionResult CustomerList()
        {
            var dogList = this._userRepository.FindUser(t=>t.Account=="test01");
            return Json(dogList, JsonRequestBehavior.AllowGet);
        }
    }
}