using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain.core
{   



    /// <summary>
    /// 出入库信息表
    /// </summary>
   public class Stock:Entity
    {   
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 产品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 出库/入库
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 可见范围
        /// </summary>
        public string Viewable { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 组织ID
        /// </summary>
        public System.Guid OrgId { get; set; }
    }
}
