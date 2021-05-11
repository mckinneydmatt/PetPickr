namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
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
                    })
                .PrimaryKey(t => t.ShelterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shelter");
        }
    }
}
