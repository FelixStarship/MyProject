using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMigration.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage ="订单描述必填")]
        public string OrderTitle { get; set; }
    }
}