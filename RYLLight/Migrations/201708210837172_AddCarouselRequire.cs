namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarouselRequire : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carousels", "PicturePath", c => c.String(nullable: false));
            AlterColumn("dbo.Carousels", "MobilePicturePath", c => c.String(nullable: false));
            AlterColumn("dbo.Carousels", "PictureName", c => c.String(nullable: false));
            AlterColumn("dbo.Carousels", "PictureDes", c => c.String(nullable: false));
            AlterColumn("dbo.Carousels", "PictureTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carousels", "PictureTitle", c => c.String());
            AlterColumn("dbo.Carousels", "PictureDes", c => c.String());
            AlterColumn("dbo.Carousels", "PictureName", c => c.String());
            AlterColumn("dbo.Carousels", "MobilePicturePath", c => c.String());
            AlterColumn("dbo.Carousels", "PicturePath", c => c.String());
        }
    }
}
