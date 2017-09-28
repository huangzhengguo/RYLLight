namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAllTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyInfoes", "TypeProduct", c => c.Int(nullable: false));
            AddColumn("dbo.News", "TypeProduct", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyInfoes", "typeOfProduct");
            DropColumn("dbo.News", "typeOfProduct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "typeOfProduct", c => c.Int(nullable: false));
            AddColumn("dbo.CompanyInfoes", "typeOfProduct", c => c.Int(nullable: false));
            DropColumn("dbo.News", "TypeProduct");
            DropColumn("dbo.CompanyInfoes", "TypeProduct");
        }
    }
}
