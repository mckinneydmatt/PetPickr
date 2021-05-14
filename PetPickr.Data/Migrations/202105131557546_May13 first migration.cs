namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class May13firstmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "UserRoles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "UserRoles");
        }
    }
}
