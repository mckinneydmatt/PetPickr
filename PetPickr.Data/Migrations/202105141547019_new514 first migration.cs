namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new514firstmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "Role", c => c.String());
            DropColumn("dbo.ApplicationUser", "UserRoles");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "UserRoles", c => c.String());
            DropColumn("dbo.ApplicationUser", "Role");
        }
    }
}
