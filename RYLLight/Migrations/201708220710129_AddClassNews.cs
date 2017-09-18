namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassNews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 64),
                        SubTitle = c.String(nullable: false, maxLength: 64),
                        Thumbnail = c.String(nullable: false),
                        Picture = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Author = c.String(nullable: false, maxLength: 32),
                        PublishDateTime = c.DateTime(nullable: false),
                        EditDateTime = c.DateTime(),
                        PublishOrNot = c.Boolean(nullable: false),
                        SortNumber = c.Int(nullable: false),
                        NewsBackgroundImg = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Ppf", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Products", "Spectrum", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "InputVoltage", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "OutputVoltage", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "InputPower", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "OutputPower", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "Weight", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "Heat", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "ApplicationSceneName", c => c.String(nullable: false, maxLength: 64));
            DropColumn("dbo.Products", "FreeOne");
            DropColumn("dbo.Products", "FreeTwo");
            DropColumn("dbo.Products", "FreeThree");
            DropTable("dbo.CompanyNews");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Products", "FreeThree", c => c.String());
            AddColumn("dbo.Products", "FreeTwo", c => c.String());
            AddColumn("dbo.Products", "FreeOne", c => c.String());
            AlterColumn("dbo.Products", "ApplicationSceneName", c => c.String());
            AlterColumn("dbo.Products", "Heat", c => c.String(maxLength: 32));
            AlterColumn("dbo.Products", "Weight", c => c.String(maxLength: 32));
            AlterColumn("dbo.Products", "OutputPower", c => c.String());
            AlterColumn("dbo.Products", "InputPower", c => c.String());
            AlterColumn("dbo.Products", "OutputVoltage", c => c.String());
            AlterColumn("dbo.Products", "InputVoltage", c => c.String());
            DropColumn("dbo.Products", "Spectrum");
            DropColumn("dbo.Products", "Ppf");
            DropTable("dbo.News");
        }
    }
}
