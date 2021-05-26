namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tuesdaysecondmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dog", "DogImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dog", "DogImage", c => c.String(nullable: false));
        }
    }
}
