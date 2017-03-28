using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMigration.Models;
using TestMigration.Repository;
using TestMigration.Domain.Interface;
using TestMigration.Domain.core;

namespace TestMigration.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        //http://www.cnblogs.com/netxiaohui/p/5906290.html
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user=this._userRepository.FindUser(t => t.Account == model.Account && t.Password == model.Password);
                if (user != null)
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Register");
            }
            else
            {
                string errorMessage = ModelState.Values.Where(t => t.Errors.Count > 0).FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
                return View(model);
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Account = model.Account,
                    Name = model.Name,
                    BizCode = System.Guid.NewGuid().ToString(),
                    CrateId = System.Guid.NewGuid(),
                    CreateTime = DateTime.Now,
                    Password = model.Password,
                    Sex = model.Sex,
                    Status = true,
                    Type = 0
                };
                var result = this._userRepository.AddUser(user);
                if (result)
                    return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}