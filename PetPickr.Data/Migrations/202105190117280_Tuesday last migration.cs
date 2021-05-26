namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tuesdaylastmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "FullName");
        }
    }
}
