namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carousels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PicturePath = c.String(),
                        MobilePicturePath = c.String(),
                        SortNumber = c.Int(nullable: false),
                        PictureName = c.String(),
                        PictureDes = c.String(),
                        PictureTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 200),
                        CompanyAddress = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        MailBox = c.String(nullable: false),
                        CompanyDescription = c.String(nullable: false),
                        FreeOne = c.String(),
                        FreeTwo = c.String(),
                        FreeThree = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsTitle = c.String(),
                        NewsAbstract = c.String(),
                        NewsContent = c.String(),
                        NewsPicturePath = c.String(),
                        FreeOne = c.String(),
                        FreeTwo = c.String(),
                        FreeThree = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactInfo = c.String(),
                        Message = c.String(),
                        FreeOne = c.String(),
                        FreeTwo = c.String(),
                        FreeThree = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetailProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductType = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductCode = c.String(),
                        ProductPower = c.String(),
                        ProductLumen = c.String(),
                        ProductColorAngle = c.String(),
                        Efficient = c.String(),
                        Dimming = c.String(),
                        DetailProductPicturePath = c.String(),
                        FreeOne = c.String(),
                        FreeTwo = c.String(),
                        FreeThree = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(nullable: false),
                        ProductName = c.String(nullable: false),
                        ProductType = c.Int(nullable: false),
                        ProductDes = c.String(nullable: false),
                        ProductPower = c.String(nullable: false),
                        ProductLength = c.String(nullable: false),
                        ProductLumen = c.String(nullable: false),
                        LightingAngle = c.String(nullable: false),
                        Efficient = c.String(),
                        Dimming = c.String(),
                        ApplicationSceneName = c.String(),
                        ApplicationScenePath = c.String(),
                        MobileProductPicturePath = c.String(),
                        ProductPicturePath = c.String(nullable: false),
                        ProductTitlePicturePath = c.String(),
                        ProductTitleWhitePicturePath = c.String(),
                        ProductGuide = c.String(),
                        ProductInstallationGuide = c.String(),
                        ProductDatasheet = c.String(),
                        ProductIes = c.String(),
                        ProductSceneId = c.Int(nullable: false),
                        FreeOne = c.String(),
                        FreeTwo = c.String(),
                        FreeThree = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductScenes", t => t.ProductSceneId, cascadeDelete: true)
                .Index(t => t.ProductSceneId);
            
            CreateTable(
                "dbo.PreviewProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureName = c.String(),
                        ProductPicturePath = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductFeatureName = c.String(),
                        ProductFeaturePicturePath = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductScenes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SceneName = c.String(),
                        SceneDescription = c.String(),
                        ApplicationScenePicturePath = c.String(),
                        ScenePicturePath = c.String(),
                        FreeOne = c.String(),
                        FreeTwo = c.String(),
                        FreeThree = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuTitle = c.String(),
                        Sortnumber = c.Int(nullable: false),
                        Link = c.String(),
                        FreeOne = c.String(),
                        FreeTwo = c.String(),
                        FreeThree = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NickName = c.String(),
                        PhoneNumber = c.String(),
                        MailBox = c.String(),
                        Skype = c.String(),
                        FreeOne = c.String(),
                        FreeTwo = c.String(),
                        FreeThree = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductSceneId", "dbo.ProductScenes");
            DropForeignKey("dbo.ProductFeatures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PreviewProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.DetailProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductFeatures", new[] { "ProductId" });
            DropIndex("dbo.PreviewProducts", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ProductSceneId" });
            DropIndex("dbo.DetailProducts", new[] { "ProductId" });
            DropTable("dbo.SaleContactInfoes");
            DropTable("dbo.Menus");
            DropTable("dbo.Logoes");
            DropTable("dbo.ProductScenes");
            DropTable("dbo.ProductFeatures");
            DropTable("dbo.PreviewProducts");
            DropTable("dbo.Products");
            DropTable("dbo.DetailProducts");
            DropTable("dbo.ContactMessages");
            DropTable("dbo.CompanyNews");
            DropTable("dbo.CompanyInfoes");
            DropTable("dbo.Carousels");
        }
    }
}
