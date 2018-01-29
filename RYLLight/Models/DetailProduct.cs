using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RYLLight.Models
{
    public class DetailProduct
    {
        // 产品子表
        public int Id { get; set; }

        // 子产品类型
        public TypeOfSubProduct ProductType { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        // 产品编码
        public string ProductCode { get; set; }

        // 功率
        public string ProductPower { get; set; }

        // 流明
        public string ProductLumen { get; set; }

        // 光角
        public string ProductColorAngle { get; set; }

        // 效率
        public string Efficient { get; set; }

        // 调光
        public string Dimming { get; set; }

        // 子产品图片路径
        public string DetailProductPicturePath { get; set; }

        // 备用字段
        public string FreeOne { get; set; }

        public string FreeTwo { get; set; }

        public string FreeThree { get; set; }

        // 主表Id
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}