namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductInputPower : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "InputPower", c => c.String());
            AddColumn("dbo.Products", "OutputPower", c => c.String());
            AddColumn("dbo.Products", "Weight", c => c.String(maxLength: 32));
            AddColumn("dbo.Products", "Heat", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Heat");
            DropColumn("dbo.Products", "Weight");
            DropColumn("dbo.Products", "OutputPower");
            DropColumn("dbo.Products", "InputPower");
        }
    }
}
