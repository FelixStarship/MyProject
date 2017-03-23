using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain.core
{   
    /// <summary>
    /// 模块元素表（需要权限控制的按钮）
    /// </summary>
   public class ModuleElement:Entity
    {   
        /// <summary>
        /// DOM Id
        /// </summary>
        public string DomId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>

        public string Type { get; set; }
        /// <summary>
        /// 元素附加属性
        /// </summary>
        public string Attr { get; set; }
        /// <summary>
        /// 元素调用脚本
        /// </summary>

        public string Script { get; set; }
        /// <summary>
        /// 元素调用图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 元素样式
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        ///排序字段
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 功能模块Id
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// 功能模块
        /// </summary>
        public Module Module { get; set; }
    }
}
