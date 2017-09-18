using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RYLLight.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }

        // 特点名称
        public string ProductFeatureName { get; set; }

        // 特点图片路径
        public string ProductFeaturePicturePath { get; set; }

        // 关联的产品
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}