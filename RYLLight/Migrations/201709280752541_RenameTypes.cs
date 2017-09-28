namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carousels", "TypeProduct", c => c.Int(nullable: false));
            DropColumn("dbo.Carousels", "typeOfProduct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carousels", "typeOfProduct", c => c.Int(nullable: false));
            DropColumn("dbo.Carousels", "TypeProduct");
        }
    }
}
