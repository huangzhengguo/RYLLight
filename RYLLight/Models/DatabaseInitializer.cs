using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace RYLLight.Models
{
    // 初始化数据库
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<RyllightEntities>
    {
        protected override void Seed(RyllightEntities context)
        {
            // 开发阶段初始化添加一些数据
            // 初始化菜单数据
            context.Menus.AddOrUpdate(m => m.MenuTitle,
                        new Menu { MenuTitle = "APPLICATION", Sortnumber = 0, Link = "ApplicationScene" },
                        new Menu { MenuTitle = "LIGHTING", Sortnumber = 1, Link = "Lighting" },
                        new Menu { MenuTitle = "INTELLGENTCONTROL", Sortnumber = 2, Link = "Intellgentcontrol" },
                        new Menu { MenuTitle = "LED GROW LIGHT", Sortnumber = 3, Link = "Horticulture" },
                        new Menu { MenuTitle = "LED AQUARIUM LIGHT",Sortnumber = 4,Link = "Aquarium"},
                        new Menu { MenuTitle = "COMPANY", Sortnumber = 5, Link = "Company" });

            // 轮播图数据
            context.Carousels.AddOrUpdate(
                new Carousel
                {
                    Id = 1,
                    PicturePath = "/Upload/2017323149280.jpg",
                    MobilePicturePath = "/Upload/2017323149280.jpg",
                    SortNumber = 0,
                    PictureName = "轮播图1",
                    PictureDes = "New optic desigen,up to 150lm/w  Free wiring and easy maintenance",
                    PictureTitle = "LI232 Linear Trunking System"
                },
                new Carousel
                {
                    Id = 2,
                    PicturePath = "/Upload/2017323149280.jpg",
                    MobilePicturePath = "/Upload/2017323149280.jpg",
                    SortNumber = 0,
                    PictureName = "轮播图1",
                    PictureDes = "New optic desigen,up to 150lm/w  Free wiring and easy maintenance",
                    PictureTitle = "LI232 Linear Trunking System"
                },
                new Carousel
                {
                    Id = 3,
                    PicturePath = "/Upload/2017323149280.jpg",
                    MobilePicturePath = "/Upload/2017323149280.jpg",
                    SortNumber = 0,
                    PictureName = "轮播图1",
                    PictureDes = "New optic desigen,up to 150lm/w  Free wiring and easy maintenance",
                    PictureTitle = "LI232 Linear Trunking System"
                }
                );

            // 添加场景数据
            context.ProductScenes.AddOrUpdate(
                new ProductScene
                {
                    Id = 1,
                    SceneName = "场景1",
                    SceneDescription = "OFFICE",
                    ApplicationScenePicturePath = "/Upload/20173231420560.png",
                    ScenePicturePath = "/Upload/20173231424140123.png"
                },
                new ProductScene
                {
                    Id = 2,
                    SceneName = "场景1",
                    SceneDescription = "OFFICE",
                    ApplicationScenePicturePath = "/Upload/20173231420560.png",
                    ScenePicturePath = "/Upload/20173231424140123.png"
                },
                new ProductScene
                {
                    Id = 3,
                    SceneName = "场景1",
                    SceneDescription = "OFFICE",
                    ApplicationScenePicturePath = "/Upload/20173231420560.png",
                    ScenePicturePath = "/Upload/20173231424140123.png"
                });


            // 添加产品
            context.Products.AddOrUpdate(
                new Product
                {
                    Id = 1,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.LIGHTING,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 1
                },
                new Product
                {
                    Id = 2,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.LIGHTING,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 1
                },
                new Product
                {
                    Id = 3,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.LIGHTING,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 1
                }
                ,
                new Product
                {
                    Id = 4,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.LIGHTING,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                ,
                new Product
                {
                    Id = 5,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.INTELLGENTCONTROL,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                ,
                new Product
                {
                    Id = 6,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.INTELLGENTCONTROL,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                ,
                new Product
                {
                    Id = 7,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.INTELLGENTCONTROL,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                ,
                new Product
                {
                    Id = 8,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.INTELLGENTCONTROL,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                ,
                new Product
                {
                    Id = 9,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.HORTICULTURE,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                ,
                new Product
                {
                    Id = 10,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.HORTICULTURE,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                ,
                new Product
                {
                    Id = 11,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.HORTICULTURE,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                ,
                new Product
                {
                    Id = 12,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.HORTICULTURE,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                ,
                new Product
                {
                    Id = 13,
                    ProductCode = "LL231",
                    ProductName = "LL231",
                    ProductType = TypeOfProduct.LIGHTING,
                    ProductDes = "LL232 is a waterproof led linear light Designed for industrial applications 结构材料，适用",
                    ProductPower = "18W - 130W",
                    ProductLength = "1200mm",
                    ProductLumen = "16900lm",
                    LightingAngle = "45/60",
                    Efficient = "1000",
                    Dimming = "1000",
                    ApplicationSceneName = "OFFICE",
                    ApplicationScenePath = "/Upload/20173231424140123.png",
                    ProductPicturePath = "/Upload/20173231424140.png",
                    MobileProductPicturePath = "/Upload/20173231424140.png",
                    ProductGuide = "/Upload/201732314241401234.pdf",
                    ProductInstallationGuide = "/Upload/2017323142414012345.pdf",
                    ProductDatasheet = "/Upload/20173231424140123456.pdf",
                    ProductIes = "/Upload/201732314241401234567.png",
                    ProductSceneId = 2
                }
                );

            // 子产品
            context.DetailProducts.AddOrUpdate(
                new DetailProduct
                {
                    Id = 1,
                    ProductType = TypeOfSubProduct.SPECIFICATION,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                },
                new DetailProduct
                {
                    ProductType = TypeOfSubProduct.SPECIFICATION,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                },
                new DetailProduct
                {
                    Id = 2,
                    ProductType = TypeOfSubProduct.SPECIFICATION,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                },
                new DetailProduct
                {
                    Id = 3,
                    ProductType = TypeOfSubProduct.SPECIFICATION,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                },
                new DetailProduct
                {
                    Id = 4,
                    ProductType = TypeOfSubProduct.SPECIFICATION,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                },
                new DetailProduct
                {
                    Id = 5,
                    ProductType = TypeOfSubProduct.SPECIFICATION,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                },
                new DetailProduct
                {
                    Id = 6,
                    ProductType = TypeOfSubProduct.SPECIFICATION,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                },
                new DetailProduct
                {
                    Id = 7,
                    ProductType = TypeOfSubProduct.SPECIFICATION,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                }
                ,
                new DetailProduct
                {
                    Id = 8,
                    ProductType = TypeOfSubProduct.ACCESSORIES,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                }
                ,
                new DetailProduct
                {
                    Id = 8,
                    ProductType = TypeOfSubProduct.ACCESSORIES,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                }
                ,
                new DetailProduct
                {
                    Id = 9,
                    ProductType = TypeOfSubProduct.ACCESSORIES,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                }
                ,
                new DetailProduct
                {
                    Id = 10,
                    ProductType = TypeOfSubProduct.ACCESSORIES,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                }
                ,
                new DetailProduct
                {
                    Id = 11,
                    ProductType = TypeOfSubProduct.ACCESSORIES,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                }
                ,
                new DetailProduct
                {
                    Id = 12,
                    ProductType = TypeOfSubProduct.ACCESSORIES,
                    ProductName = "name",
                    ProductCode = "code",
                    ProductPower = "power",
                    ProductLumen = "lumen",
                    ProductColorAngle = "colorAngle",
                    Efficient = "efficent",
                    Dimming = "dimming",
                    DetailProductPicturePath = "/Upload/20173231424140.png",
                    ProductId = 1
                }
                );

            // 产品预览图
            context.PreviewProducts.AddOrUpdate(
                new PreviewProduct
                {
                    Id = 1,
                    PictureName = "预览图1",
                    ProductPicturePath = "/Upload/2017323142449.jpg",
                    ProductId = 1
                },
                new PreviewProduct
                {
                    Id = 2,
                    PictureName = "预览图1",
                    ProductPicturePath = "/Upload/2017323142449.jpg",
                    ProductId = 1
                },
                new PreviewProduct
                {
                    Id = 3,
                    PictureName = "预览图1",
                    ProductPicturePath = "/Upload/2017323142449.jpg",
                    ProductId = 1
                },
                new PreviewProduct
                {
                    Id = 4,
                    PictureName = "预览图1",
                    ProductPicturePath = "/Upload/2017323142449.jpg",
                    ProductId = 1
                }
                );

            // 特点图标
            context.ProductFeature.AddOrUpdate(
                new ProductFeature
                {
                    Id = 1,
                    ProductFeatureName = "name",
                    ProductFeaturePicturePath = "/Upload/2017323142522.png",
                    ProductId = 1
                },
                new ProductFeature
                {
                    Id = 2,
                    ProductFeatureName = "name",
                    ProductFeaturePicturePath = "/Upload/2017323142522.png",
                    ProductId = 1
                },
                new ProductFeature
                {
                    Id = 3,
                    ProductFeatureName = "name",
                    ProductFeaturePicturePath = "/Upload/2017323142522.png",
                    ProductId = 1
                }
                );
                
            context.SaveChanges();
            base.Seed(context);
        }
    }
}