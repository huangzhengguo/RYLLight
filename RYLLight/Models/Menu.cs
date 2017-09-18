using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RYLLight.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuTitle { get; set; }
        public int Sortnumber { get; set; }

        // 链接
        public string Link { get; set; }

        // 备用字段
        public string FreeOne { get; set; }
        public string FreeTwo { get; set; }
        public string FreeThree { get; set; }
    }
}