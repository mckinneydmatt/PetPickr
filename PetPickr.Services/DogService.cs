using PetPickr.Data;
using PetPickr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Services
{
    public class DogService
    {
        public bool CreateDog(DogCreate model)
        {
            var entity =
                new Dog()
                {
                    DogName = model.DogName,
                    DogBreed = model.DogBreed,
                    DogSex = model.DogSex,
                    DogWeight = model.DogWeight,
                    DogAge = model.DogAge,
                    DogPrice = model.DogPrice,
                    DogImage = model.DogImage,
                    ShelterId = model.ShelterId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dogs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DogListItem> GetDogs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Dogs
                        .Select(
                            e =>
                                new DogListItem
                                {
                                    DogId = e.DogId,
                                    DogName = e.DogName,
                                    DogBreed = e.DogBreed,
                                    DogPrice = e.DogPrice,
                                    ShelterName = e.Shelter.ShelterName
                                }
                        );

                return query.ToArray();
            }
        }
        public DogDetail GetDogById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                // get dog from ID
                var dog = ctx.Dogs.Single(e => e.DogId == id);

                return new DogDetail
                {
                    DogId = dog.DogId,
                    DogName = dog.DogName,
                    DogBreed = dog.DogBreed,
                    DogSex = dog.DogSex,
                    DogWeight = dog.DogWeight,
                    DogAge = dog.DogAge,
                    DogPrice = dog.DogPrice,
                    DogImage = dog.DogImage,
                    ShelterId = dog.ShelterId,
                    ShelterName = dog.Shelter.ShelterName
                 };
            }
        }
        public bool UpdateDog(DogEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dogs
                    .Single(e => e.DogId == model.DogId);
                entity.DogName = model.DogName;
                entity.DogBreed = model.DogBreed;
                entity.DogSex = model.DogSex;
                entity.DogWeight = model.DogWeight;
                entity.DogAge = model.DogAge;
                entity.DogImage = model.DogImage;
                entity.DogPrice = model.DogPrice;
                entity.ShelterId = model.ShelterId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteDog(int dogId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dogs
                    .Single(e => e.DogId == dogId);
                ctx.Dogs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
