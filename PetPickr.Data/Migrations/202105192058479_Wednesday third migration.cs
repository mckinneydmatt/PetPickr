namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wednesdaythirdmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cat", "ImageFile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cat", "ImageFile");
        }
    }
}