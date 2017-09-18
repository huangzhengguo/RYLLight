using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RYLLight.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        // 联系信息
        public string ContactInfo { get; set; }

        // 内容
        public string Message { get; set; }

        // 备用字段
        public string FreeOne { get; set; }
        public string FreeTwo { get; set; }
        public string FreeThree { get; set; }
    }
}