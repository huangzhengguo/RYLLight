using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RYLLight.Models
{
    /// <summary>
    /// 菜单实体类
    /// </summary>
    public class Menu
    {
        public int Id { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        public string MenuTitle { get; set; }

        /// <summary>
        /// 排序编号
        /// </summary>
        public int Sortnumber { get; set; }

        /// <summary>
        /// 菜单链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        public string FreeOne { get; set; }
        public string FreeTwo { get; set; }
        public string FreeThree { get; set; }
    }
}