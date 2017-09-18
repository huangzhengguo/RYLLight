using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace RYLLight.Models
{
    // 产品类型枚举:灯具分类
    public enum TypeOfProduct
    {
        [Display(Name = "商业照明")]
        LIGHTING = 0,
        [Display(Name = "智能控制")]
        INTELLGENTCONTROL = 1,
        [Display(Name = "植物照明")]
        HORTICULTURE = 2,
        [Display(Name = "水族照明")]
        AQUARIUM = 3,
        [Display(Name = "其它类型")]
        LightingTypeEnd = 4
    }

    // 子产品类型
    public enum TypeOfSubProduct
    {
        [Display(Name = "规格")]
        SPECIFICATION = 0,
        [Display(Name = "配件")]
        ACCESSORIES = 1,
        [Display(Name = "其它类型")]
        OTHERTYPE = 2
    }

    public class RyllightEntities : DbContext
    {
        /**private const string connectionString = @"server=(localdb)\v11.0;database=Ryllight;trusted_connection=true";
         *  如果提供
            如果不写初始化，则会根据服务器安装的数据库提供程序自动生成数据库
            数据库名称为RYLLight.Models.RyllightEntities
            public RyllightEntities() : base(connectionString)
        {

        }*/

        // 设置数据库初始化策略，就是数据库进行怎样的初始化
        /**
        public RyllightEntities()
        {
            Database.SetInitializer<RyllightEntities>(new DropCreateDatabaseIfModelChanges<RyllightEntities>());
        }*/

        // logo数据 
        public DbSet<Logo> Logos { get; set; }

        // 菜单数据
        public DbSet<Menu> Menus { get; set; }

        // 产品
        public DbSet<Product> Products { get; set; }

        // 产品明细表
        public DbSet<DetailProduct> DetailProducts { get; set; }

        // 轮播图数据
        public DbSet<Carousel> Carousels { get; set; }

        // 三级页面预览图片
        public DbSet<PreviewProduct> PreviewProducts { get; set; }

        // 产品特点图片
        public DbSet<ProductFeature> ProductFeature { get; set; }

        // 系统自动添加了
        public DbSet<ProductScene> ProductScenes { get; set; }

        // 公司信息
        public DbSet<CompanyInfo> CompanyInfos { get; set; }

        // 留言信息
        public DbSet<ContactMessage> ContactMessages { get; set; }

        // 业务员联系信息
        public DbSet<SaleContactInfo> SaleContactInfos { get; set; }

        // 公司新闻
        public DbSet<News> CompanyNews { get; set; }
    }
}