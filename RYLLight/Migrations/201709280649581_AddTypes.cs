namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carousels", "typeOfProduct", c => c.Int(nullable: false));
            AddColumn("dbo.CompanyInfoes", "typeOfProduct", c => c.Int(nullable: false));
            AddColumn("dbo.News", "typeOfProduct", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "typeOfProduct");
            DropColumn("dbo.CompanyInfoes", "typeOfProduct");
            DropColumn("dbo.Carousels", "typeOfProduct");
        }
    }
}
