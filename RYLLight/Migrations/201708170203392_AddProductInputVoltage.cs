namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductInputVoltage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "InputVoltage", c => c.String());
            AddColumn("dbo.Products", "OutputVoltage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "OutputVoltage");
            DropColumn("dbo.Products", "InputVoltage");
        }
    }
}
