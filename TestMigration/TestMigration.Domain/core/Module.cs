using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain.core
{  
    /// <summary>
    /// 功能模块表
    /// </summary>
   public class Module:Entity
    {   
        /// <summary>
        /// 节点语义Id
        /// </summary>
        public string CascadeId { get; set; }

        /// <summary>
        /// 功能模块名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 主页面URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 热键
        /// </summary>
        public string HotKey { get; set; }
        /// <summary>
        /// 是否叶子节点
        /// </summary>
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 是否自动展开
        /// </summary>
        public bool IsAutoExpand { get; set; }
        /// <summary>
        /// 节点图标文件名
        /// </summary>
        public string IconName { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 父节点名称
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 矢量图标
        /// </summary>
        public string Vector { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNo { get; set; }
        /// <summary>
        /// 父节点流水号
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 模块元素表（需要权限控制的按钮）
        /// </summary>
        public virtual List<ModuleElement> ModuleElement { get; set; }
    }
}
