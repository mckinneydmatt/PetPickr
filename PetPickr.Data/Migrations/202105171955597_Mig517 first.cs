namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig517first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cat", "CatSex", c => c.Int(nullable: false));
            AddColumn("dbo.Dog", "DogSex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dog", "DogSex");
            DropColumn("dbo.Cat", "CatSex");
        }
    }
}
