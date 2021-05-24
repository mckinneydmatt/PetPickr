namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wednesdayfirstmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shelter", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shelter", "OwnerId");
        }
    }
}
