using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMigration.Models
{
    public class LoginViewModel
    {   



        [Required]
        [Display(Name = "用户名")]
        public string Account { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }


    }
}