namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dog",
                c => new
                    {
                        DogId = c.Int(nullable: false, identity: true),
                        DogName = c.String(nullable: false),
                        DogBreed = c.String(nullable: false),
                        DogWeight = c.Int(nullable: false),
                        DogAge = c.Int(nullable: false),
                        DogPrice = c.Double(nullable: false),
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DogId)
                .ForeignKey("dbo.Shelter", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dog", "ShelterId", "dbo.Shelter");
            DropIndex("dbo.Dog", new[] { "ShelterId" });
            DropTable("dbo.Dog");
        }
    }
}
