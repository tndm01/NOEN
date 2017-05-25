namespace NOEN.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductViewModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductCategories", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategories", "Image", c => c.String());
        }
    }
}
