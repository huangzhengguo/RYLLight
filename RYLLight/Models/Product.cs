using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RYLLight.Models
{
    public class Product
    {
        public int Id { get; set; }

        // 产品型号
        [Display(Name = "产品编码")]
        [Required]
        public string ProductCode { get; set; }

        // 产品名称
        [Display(Name = "产品名称")]
        [Required]
        public string ProductName { get; set; }

        // 产品分类
        [Display(Name = "产品类型")]
        public TypeOfProduct ProductType { get; set; }

        // 产品描述
        [Required]
        [Display(Name = "产品描述")]
        public string ProductDes { get; set; }

        // 功率
        [Display(Name = "功率")]
        [Required]
        public string ProductPower { get; set; }

        // 长度
        [Required]
        [Display(Name = "长度")]
        public string ProductLength { get; set; }

        // 流明
        [Display(Name = "流明")]
        [Required]
        public string ProductLumen { get; set; }

        // 光角
        [Display(Name = "光角")]
        [Required]
        public string LightingAngle { get; set; }

        // 效率
        [Display(Name = "光效")]
        public string Efficient { get; set; }

        // 调光
        [Display(Name = "调光")]
        public string Dimming { get; set; }

        // 输入输出电压
        [Display(Name = "输入电压")]
        //[Required(ErrorMessage = "请输入输入电压！")]
        [MaxLength(32)]
        public string InputVoltage { get; set; }
        [Display(Name = "输出电压")]
        //[Required(ErrorMessage = "请输入输输出电压！")]
        [MaxLength(32)]
        public string OutputVoltage { get; set; }

        // 输入输出功率
        [Display(Name ="输入功率")]
        //[Required(ErrorMessage = "请输入输入功率！")]
        [MaxLength(32)]
        public string InputPower { get; set; }
        [Display(Name = "输出功率")]
        //[Required(ErrorMessage = "请输入输出功率！")]
        [MaxLength(32)]
        public string OutputPower { get; set; }

        // 重量
        [MaxLength(32)]
        [Display (Name ="重量")]
        //[Required(ErrorMessage = "请输入重量！")]
        public string Weight { get; set; }

        // 发热
        [MaxLength(32)]
        [Display(Name = "发热")]
        // [Required(ErrorMessage = "请输入发热！")]
        public string Heat { get; set; }

        // 具体应用场景名称
        [Display(Name = "应用场景名称")]
        //[Required(ErrorMessage = "请输入应用场景名称！")]
        [MaxLength(64)]
        public string ApplicationSceneName { get; set; }

        // PPF
        [Display(Name = "PPF")]
        //[Required(ErrorMessage = "请输入PPF!")]
        [MaxLength(255)]
        public string Ppf { get; set; }

        [Display(Name = "光谱")]
        //[Required(ErrorMessage = "请输入Spectrum！")]
        public string Spectrum { get; set; }

        // 具体应用场景图片路径
        [Display(Name = "应用场景图片")]
        public string ApplicationScenePath { get; set; }

        // 手机版图片
        [Display(Name = "手机版产品图片")]
        public string MobileProductPicturePath { get; set; }

        // 图片:首页及二级页面显示用只上传一张图片
        [Required]
        [Display(Name = "电脑版产品图片")]
        public string ProductPicturePath { get; set; }

        // 产品指导书
        [Display(Name = "产品指导书")]
        public string ProductGuide { get; set; }

        // 安装指导书
        [Display(Name = "安装指导书")]
        public string ProductInstallationGuide { get; set; }

        // datasheet
        [Display(Name = "产品Datasheet文件")]
        public string ProductDatasheet { get; set; }

        // IES文件
        [Display(Name = "产品IES文件")]
        public string ProductIes { get; set; }

        // 背景图片
        [Display(Name = "背景图片")]
        public string ProductBackgroundImage { get; set; }

        // 子产品列表
        public virtual List<DetailProduct> DetailProducts { get; set; }

        // 预览图片
        public virtual List<PreviewProduct> PreviewProducts { get; set; }

        // 特点图标
        public virtual List<ProductFeature> ProductFeatures { get; set; }

        // 一个产品对应一个场景
        [Display(Name = "应用场景")]
        public int ProductSceneId { get; set; }
        public ProductScene ProductScene { get; set; }
    }
}