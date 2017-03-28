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
        private IEnumerable<Category> ztreeObject = new List<Category>
        {
           new Category { Id=1, Description="订单查询", Name="订单查询", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=0},
           new Category { Id=2,Description="待付款订单",Name="待付款订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=1},
           new Category { Id=3,Description="待核销订单",Name="待核销订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=1},
           new Category { Id=4,Description="团购订单",Name="团购订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=1},
           new Category { Id=5,Description="特卖订单",Name="特卖订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=1},
           new Category { Id=6,Description="秒杀订单",Name="秒杀订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=1},
           new Category { Id=7, Description="个人中心", Name="个人中心", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=0},
           new Category { Id=8, Description="修改密码", Name="修改密码", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=7},
           new Category { Id=9, Description="修改手机号", Name="修改手机号", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=7},
           new Category { Id=10, Description="修改用户名", Name="修改用户名", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=7},
           new Category { Id=11, Description="修改昵称", Name="修改昵称", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=7},
           new Category { Id=12, Description="修改密码", Name="修改密码", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=7},
           new Category { Id=13, Description="修改密码", Name="修改密码", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=7},
           new Category { Id=14, Description="修改密码", Name="修改密码", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=7},
           new Category { Id=15, Description="修改密码", Name="修改密码", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=7},
           new Category { Id=16, Description="修改密码", Name="修改密码", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=7},
        };

        [HttpPost]
        public JsonResult GetCategories()
        {
            return Json(ztreeObject);
        }

        public JsonResult addtree(int pid,string name)
        {
           return Json(new {Id=19,Name="新添加节点", ParentId=1 });
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


        public int Id { get; set; }
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