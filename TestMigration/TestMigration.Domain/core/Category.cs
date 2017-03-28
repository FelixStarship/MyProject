using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain.core
{   
    /// <summary>
    /// 分类表
    /// </summary>
    public class Category:Entity
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
