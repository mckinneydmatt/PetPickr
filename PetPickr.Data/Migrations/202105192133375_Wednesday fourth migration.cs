namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wednesdayfourthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cat", "CatImage", c => c.String());
            DropColumn("dbo.Cat", "ImageFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cat", "ImageFile", c => c.String());
            DropColumn("dbo.Cat", "CatImage");
        }
    }
}
