namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wednesdaysecondmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Shelter", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shelter", "OwnerId", c => c.Guid(nullable: false));
        }
    }
}
