using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;




namespace TestMigration.Models
{
    public class ModuleViewModel
    {   
        /// <summary>
        /// 节点语义Id
        /// </summary>
        [Required(ErrorMessage ="节点Id必填")]
        public string CascadeId { get; set; }

        /// <summary>
        /// 功能模块名称
        /// </summary>
        [Required(ErrorMessage ="模块名称不能为空")]
        public string Name { get; set; }
        /// <summary>
        /// 主页面URL
        /// </summary>
        [Required]
        public string Url { get; set; }
        /// <summary>
        /// 热键
        /// </summary>
        [Required]
        public string HotKey { get; set; }
        /// <summary>
        /// 是否叶子节点
        /// </summary>
        [Required]
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 是否自动展开
        /// </summary>
        [Required]
        public bool IsAutoExpand { get; set; }
        /// <summary>
        /// 节点图标文件名
        /// </summary>
        [Required]
        public string IconName { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        [Required]
        public int Status { get; set; }
        /// <summary>
        /// 父节点名称
        /// </summary>
        [Required]
        public string ParentName { get; set; }
        /// <summary>
        /// 矢量图标
        /// </summary>
        [Required]
        public string Vector { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [Required]
        public int SortNo { get; set; }
        /// <summary>
        /// 父节点流水号
        /// </summary>
        [Required]
        public int ParentId { get; set; }
    }
}