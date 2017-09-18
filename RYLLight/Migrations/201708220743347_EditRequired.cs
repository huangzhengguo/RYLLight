namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "InputVoltage", c => c.String(maxLength: 32));
            AlterColumn("dbo.Products", "InputPower", c => c.String(maxLength: 32));
            AlterColumn("dbo.Products", "OutputPower", c => c.String(maxLength: 32));
            AlterColumn("dbo.Products", "Weight", c => c.String(maxLength: 32));
            AlterColumn("dbo.Products", "Heat", c => c.String(maxLength: 32));
            AlterColumn("dbo.Products", "ApplicationSceneName", c => c.String(maxLength: 64));
            AlterColumn("dbo.Products", "Ppf", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "Spectrum", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Spectrum", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Ppf", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Products", "ApplicationSceneName", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Products", "Heat", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "Weight", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "OutputPower", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "InputPower", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Products", "InputVoltage", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
