namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tuesdayfourthmigration : DbMigration
    {
        public override void Up()
        {
                        
            CreateTable(
                "dbo.Shelter",
                c => new
                    {
                        ShelterId = c.Int(nullable: false, identity: true),
                        ShelterName = c.String(nullable: false),
                        ShelterAddress = c.String(nullable: false),
                        ShelterPhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShelterId);
            
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Cat", "ShelterId", "dbo.Shelter");
            DropForeignKey("dbo.Dog", "ShelterId", "dbo.Shelter");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Dog", new[] { "ShelterId" });
            DropIndex("dbo.Cat", new[] { "ShelterId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Dog");
            DropTable("dbo.Shelter");
            DropTable("dbo.Cat");
        }
    }
}
