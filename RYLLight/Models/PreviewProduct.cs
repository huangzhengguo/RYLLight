using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RYLLight.Models
{
    public class PreviewProduct
    {
        public int Id { get; set; }

        // 名称
        public string PictureName { get; set; }

        // 展示图片路径
        public string ProductPicturePath { get; set; }

        // 关联的产品
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}