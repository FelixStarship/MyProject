using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMigration.Models
{
    public class RegisterViewModel
    {   


        /// <summary>
        /// 用户登录账号
        /// </summary>
        [Required(ErrorMessage ="登录账号必填")]
        [RegularExpression("^[A-Za-z0-9]{6,20}$",ErrorMessage = "英文字母或数字组合，区分大小，长度：6-20个字符")]
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage ="密码不能为空")]
        [RegularExpression("^(?=.*[0-9,a-z,A-Z].*)[^\\s]{6,16}$", ErrorMessage = "6-16位，不区分大小写，不可含空格，不可为单纯符号，可纯英文或纯数字")]
        public string Password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage ="确认密码不能为空")]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage ="密码与确认密码不一致")]
        public string SurePassword { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required(ErrorMessage ="必填")]
        public string Name { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [Required(ErrorMessage ="必填")]
        public bool Sex { get; set; }
        
    }
}