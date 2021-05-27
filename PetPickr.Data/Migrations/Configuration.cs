namespace PetPickr.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetPickr.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetPickr.Data.ApplicationDbContext context)
        {
            context.Shelters.AddOrUpdate(s => s.ShelterId,
            new Shelter() { ShelterId = 4, ShelterName = "Indy Animal Services", ShelterAddress = "1330 N Meridian St, Indianapolis, IN 46202", ShelterPhoneNumber = "317-555-5139" },
            new Shelter() { ShelterId = 5, ShelterName = "Central Indiana Humane Society", ShelterAddress = "50 W. Ohio St, Indianapolis, IN 46202", ShelterPhoneNumber = "317-555-1344" }
            );

            context.Dogs.AddOrUpdate(d => d.DogId,
            new Dog() { DogId = 10, DogName = "Roxy", DogBreed = "Italian Greyhound", DogSex = DogSex.Female, DogWeight = 15, DogAge = 4, DogPrice = 100, ShelterId = 4, DogImage = "https://www.pixelsbin.com/images/2021/05/26/Roxy922614384e661b35.jpg" },
            new Dog() { DogId = 11, DogName = "Ira", DogBreed = "Border Collie/Mutt", DogSex = DogSex.Male, DogWeight = 30, DogAge = 6, DogPrice = 75, ShelterId = 5, DogImage = "https://www.pixelsbin.com/images/2021/05/26/Ira94351549ac81f610.jpg" },
            new Dog() { DogId = 12, DogName = "Reggie", DogBreed = "Golden Mix", DogSex = DogSex.Male, DogWeight = 10, DogAge = 1, DogPrice = 125, ShelterId = 4, DogImage = "https://www.pixelsbin.com/images/2021/05/26/Reggie185ae0a5fbac9b8c.jpg" },
            new Dog() { DogId = 13, DogName = "Maci", DogBreed = "Golden Retreiver", DogSex = DogSex.Female, DogWeight = 40, DogAge = 11, DogPrice = 50, ShelterId = 4, DogImage = "https://www.pixelsbin.com/images/2021/05/26/Maci5b96097669569e59.jpg" }
            );

            context.Cats.AddOrUpdate(c => c.CatId,
             new Cat() { CatId = 21, CatName = "Sophie", CatSex = CatSex.Female, CatWeight = 15, CatAge = 4, CatPrice = 25, ShelterId = 5, CatImage = "https://www.pixelsbin.com/images/2021/05/26/Sophieedd55482a3fff16c.jpg" },
              new Cat() { CatId = 22, CatName = "Olive", CatSex = CatSex.Female, CatWeight = 10, CatAge = 2, CatPrice = 35, ShelterId = 5, CatImage = "https://www.pixelsbin.com/images/2021/05/26/Oliveb7ac2e3f28d1dec0.jpg" }
              );
        }
    }
}
