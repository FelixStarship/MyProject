using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain
{
   public class ResultJson
    {



        /// <summary>
        /// 设置默认初始值
        /// Result:默认false
        /// Message:默认为空
        /// Data:默认为空的Object对象
        /// </summary>
        public ResultJson()
        {
            this.Result = false;
            this.Message = "";
            this.Data = new object();
            this.TotalCount = 0;
            this.PageIndex = 0;
            this.PageSize = 0;
        }

        /// <summary>
        /// 操作结果
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 返回的提示消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 开始页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 显示条数
        /// </summary>
        public int PageSize { get; set; }
    }
}
