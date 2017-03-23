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
        /// 节点语义ID
        /// </summary>
        public string CascadeId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNo { get; set; }
        /// <summary>
        /// 分类所属科目
        /// </summary>
        public string RootKey { get; set; }
        /// <summary>
        /// 分类所属科目名称
        /// </summary>
        public string RootName { get; set; }
        /// <summary>
        /// 父节点流水号
        /// </summary>
        public System.Guid ParentId { get; set; }
    }
}
