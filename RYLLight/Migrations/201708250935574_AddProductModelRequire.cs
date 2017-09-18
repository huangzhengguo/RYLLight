namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductModelRequire : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductBackgroundImage", c => c.String());
            DropColumn("dbo.Products", "ProductTitlePicturePath");
            DropColumn("dbo.Products", "ProductTitleWhitePicturePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductTitleWhitePicturePath", c => c.String());
            AddColumn("dbo.Products", "ProductTitlePicturePath", c => c.String());
            DropColumn("dbo.Products", "ProductBackgroundImage");
        }
    }
}
