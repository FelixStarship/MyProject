using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMigration.Repository;
using TestMigration.Domain.Interface;
using System.Threading.Tasks;
using TestMigration.Models;
using TestMigration.Domain.core;

namespace TestMigration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IModuleRepository _moduleRepository;
        public HomeController(IUserRepository userRepository,IModuleRepository moduleRepository)
        {
            this._userRepository = userRepository;
            this._moduleRepository = moduleRepository;
        }
        

        public ActionResult Index()
        {
            //this._userRepository.LoadUsers(1,2);
            //this._userRepository.LoadInOrgs(System.Guid.NewGuid());
            return View();
        }

        public ActionResult ModelElement()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> ModelElement(ModuleViewModel model)
        {
            var module = new Module
            {
               CascadeId=model.CascadeId,
               HotKey=model.HotKey,
               IconName=model.IconName,
               IsAutoExpand=model.IsAutoExpand,
               IsLeaf=model.IsLeaf,
               Name=model.Name,
               ParentName=model.ParentName,
               Status=1,
               Url=model.Url 
            };
            this._moduleRepository.AddUser(module);
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