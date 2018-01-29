using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.ComponentModel.DataAnnotations;

namespace RYLLight.Models
{
    /// <summary>
    /// Logo实体类
    /// </summary>
    public class Logo
    {
        public int Id { get; set; }

        // 是否是当前使用的logo
        public bool Active { get; set; }

        // logo图片路径
        public string PicturePath { get; set; }
    }
}