namespace RYLLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyBackgroudImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyInfoes", "CompanyBackgroundImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyInfoes", "CompanyBackgroundImg");
        }
    }
}
