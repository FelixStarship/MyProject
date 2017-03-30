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
        private IEnumerable<Category> ztreeObject = new List<Category>
        {
           new Category { Id=1, Description="订单查询", Name="订单查询", IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=0},
           new Category { Id=2,Description="待付款订单",Name="待付款订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=1},
           new Category { Id=3,Description="待核销订单",Name="待核销订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=2},
           new Category { Id=4,Description="团购订单",Name="团购订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=2},
           new Category { Id=5,Description="特卖订单",Name="特卖订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=2},
           new Category { Id=6,Description="秒杀订单",Name="秒杀订单",IsDisplay=true, IsEnabled=true, OrderSort=0, ParentId=3},
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
    /*
     <script type=”text/javascript”>
var zTree;
var setting = {
view:{
selectedMulti:false
},
edit: {
enable: true,
editNameSelectAll:true,
removeTitle:’删除’,
renameTitle:’重命名’
},
data: {
keep:{
parent:true,
leaf:true
},
simpleData: {
enable: true
}
},
callback:{
beforeRemove:beforeRemove,//点击删除时触发，用来提示用户是否确定删除
beforeEditName: beforeEditName,//点击编辑时触发，用来判断该节点是否能编辑
beforeRename:beforeRename,//编辑结束时触发，用来验证输入的数据是否符合要求
onRemove:onRemove,//删除节点后触发，用户后台操作
onRename:onRename,//编辑后触发，用于操作后台
beforeDrag:beforeDrag,//用户禁止拖动节点
onClick:clickNode//点击节点触发的事件
}
};
var zNodes =[
{ id:1, pId:0, name:"父节点 1", open:true},
{ id:11, pId:1, name:"去百度",url:'http://www.baidu.com',target:'_blank'},
{ id:12, pId:1, name:"叶子节点 1-2"},
{ id:13, pId:1, name:"叶子节点 1-3"},
{ id:2, pId:0, name:"父节点 2", open:true},
{ id:21, pId:2, name:"叶子节点 2-1"},
{ id:22, pId:2, name:"叶子节点 2-2"},
{ id:23, pId:2, name:"叶子节点 2-3"},
{ id:3, pId:0, name:"父节点 3", open:true},
{ id:31, pId:3, name:"叶子节点 3-1"},
{ id:32, pId:3, name:"叶子节点 3-2"},
{ id:33, pId:3, name:"叶子节点 3-3"}
];
$(document).ready(function(){
zTree = $.fn.zTree.init($(“#tree”), setting, zNodes);
});
function beforeRemove(e,treeId,treeNode){
return confirm(“你确定要删除吗？”);
}
function onRemove(e,treeId,treeNode){
if(treeNode.isParent){
var childNodes = zTree.removeChildNodes(treeNode);
var paramsArray = new Array();
for(var i = 0; i < childNodes.length; i++){
paramsArray.push(childNodes[i].id);
}
alert(“删除父节点的id为：”+treeNode.id+”\r\n他的孩子节点有：”+paramsArray.join(“,”));
return;
}
alert(“你点击要删除的节点的名称为：”+treeNode.name+”\r\n”+”节点id为：”+treeNode.id);
}
function beforeEditName(treeId,treeNode){
if(treeNode.isParent){
alert(“不准编辑非叶子节点！”);
return false;
}
return true;
}
function beforeRename(treeId,treeNode,newName,isCancel){
if(newName.length < 3){
alert(“名称不能少于3个字符！”);
return false;
}
return true;
}
function onRename(e,treeId,treeNode,isCancel){
alert(“修改节点的id为：”+treeNode.id+”\n修改后的名称为：”+treeNode.name);
}
function clickNode(e,treeId,treeNode){
if(treeNode.id == 11){
location.href=treeNode.url;
}
}
function beforeDrag(treeId,treeNodes){
return false;
}
     */
}