namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditInputRequire : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "OutputVoltage", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "OutputVoltage", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
