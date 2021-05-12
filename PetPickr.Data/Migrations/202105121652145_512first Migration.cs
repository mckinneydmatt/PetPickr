namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _512firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cat",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        CatName = c.String(nullable: false),
                        CatWeight = c.Int(nullable: false),
                        CatAge = c.Int(nullable: false),
                        CatPrice = c.Double(nullable: false),
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CatId)
                .ForeignKey("dbo.Shelter", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cat", "ShelterId", "dbo.Shelter");
            DropIndex("dbo.Cat", new[] { "ShelterId" });
            DropTable("dbo.Cat");
        }
    }
}
