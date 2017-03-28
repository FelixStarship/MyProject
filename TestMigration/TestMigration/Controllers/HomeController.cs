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
            //this._userRepository.LoadUsers(1,2);
            //this._userRepository.LoadInOrgs(System.Guid.NewGuid());
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

    /// <summary>
    /// 类别
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 品类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderSort { get; set; }
        /// <summary>
        /// 品类代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 品类描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 品类图标Url
        /// </summary>
        public string IconUrl { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsDisplay { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 父级类别主键
        /// </summary>
        public int ParentId { get; set; }
    }

}