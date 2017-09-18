using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RYLLight.Models
{
    public class SaleContactInfo
    {
        public int Id { get; set; }
        // 姓名
        public string Name { get; set; }
        // 昵称
        public string NickName { get; set; }
        // 电话
        public string PhoneNumber { get; set; }
        // 邮箱
        public string MailBox { get; set; }
        // Skype
        public string Skype { get; set; }
        // 备用字段
        public string FreeOne { get; set; }
        public string FreeTwo { get; set; }
        public string FreeThree { get; set; }
    }
}