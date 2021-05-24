using PetPickr.Data;
using PetPickr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PetPickr.Services
{
    public class CatService
    {

        public bool CreateCat(CatCreate model)
        {
            var entity = new Cat()
                {
                    CatName = model.CatName,
                    CatSex = model.CatSex,
                    CatWeight = model.CatWeight,
                    CatAge = model.CatAge,
                    CatPrice = model.CatPrice,
                    ShelterId = model.ShelterId,
                    CatImage = model.CatImage,
                };
          

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cats.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CatListItem> GetCats()
        {


            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cats
                        .Select(
                            e =>
                                new CatListItem
                                {
                                    CatId = e.CatId,
                                    CatName = e.CatName,
                                    CatWeight = e.CatWeight,
                                    CatAge = e.CatAge,
                                    CatPrice = e.CatPrice,
                                    ShelterName = e.Shelter.ShelterName
                                }
                        );

                return query.ToArray();
            }
        }
        public CatDetail GetCatById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                // get cat from ID
                var cat = ctx.Cats.Single(e => e.CatId == id);

                return new CatDetail
                {
                    CatId = cat.CatId,
                    CatName = cat.CatName,
                    CatSex = cat.CatSex,
                    CatWeight = cat.CatWeight,
                    CatAge = cat.CatAge,
                    CatPrice = cat.CatPrice,
                    ShelterName = cat.Shelter.ShelterName,
                    ShelterId = cat.ShelterId,
                    CatImage = cat.CatImage
                };
            }
        }
        public bool UpdateCat(CatEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cats
                    .Single(e => e.CatId == model.CatId);
                entity.CatName = model.CatName;
                entity.CatSex = model.CatSex;
                entity.CatWeight = model.CatWeight;
                entity.CatAge = model.CatAge;
                entity.CatPrice = model.CatPrice;
                entity.ShelterId = model.ShelterId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCat(int catId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cats
                    .Single(e => e.CatId == catId);
                ctx.Cats.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
