namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tuesdayfirstmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dog", "DogImage", c => c.String(nullable: false));
            AlterColumn("dbo.Cat", "CatImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cat", "CatImage", c => c.String());
            DropColumn("dbo.Dog", "DogImage");
        }
    }
}
