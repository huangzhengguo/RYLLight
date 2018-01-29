using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RYLLight.Models
{
    /// <summary>
    /// 业务员实体类
    /// </summary>
    public class SaleContactInfo
    {
        public int Id { get; set; }
        // 姓名
        [Display(Name = "姓名")]
        public string Name { get; set; }
        // 昵称
        [Display(Name = "昵称")]
        public string NickName { get; set; }
        // 电话
        [Display(Name = "电话")]
        public string PhoneNumber { get; set; }
        // 邮箱
        [Display(Name = "邮箱")]
        public string MailBox { get; set; }
        // Skype
        [Display(Name = "Skype")]
        public string Skype { get; set; }
        // 备用字段
        [Display(Name = "图片")]
        public string FreeOne { get; set; }
        [Display(Name = "排序")]
        public string FreeTwo { get; set; }
        public string FreeThree { get; set; }
    }
}