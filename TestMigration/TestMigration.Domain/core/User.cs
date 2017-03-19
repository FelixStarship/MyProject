using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain.core
{
   public class User:Entity
    {   
        /// <summary>
        /// 用户登录账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 业务对照码
        /// </summary>
        public string BizCode { get; set; }
        /// <summary>
        /// 经办时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 经办人流水号
        /// </summary>
        public Guid? CrateId { get; set; } 

        
    }
}
