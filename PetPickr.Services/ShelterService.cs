using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;
using PetPickr.Data;
using PetPickr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace PetPickr.Services
{
    public class ShelterService
    {
        //private readonly Guid _userId;
        //public ShelterService(Guid userId)
        //{
        //    _userId = userId;
        //}
        public bool CreateShelter(ShelterCreate model)
        {
            var entity =
                new Shelter()
                {
                    //OwnerId = _userId,
                    ShelterName = model.ShelterName,
                    ShelterAddress = model.ShelterAddress,
                    ShelterPhoneNumber = model.ShelterPhoneNumber,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shelters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
     

        public IEnumerable<ShelterListItem> GetShelters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Shelters

                        //.Where(!User.Identity.IsInRole("Admin"), e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ShelterListItem
                                {
                                    ShelterId = e.ShelterId,
                                    ShelterName = e.ShelterName,
                                    ShelterAddress = e.ShelterAddress,
                                    ShelterPhoneNumber = e.ShelterPhoneNumber
                                }
                        );

                return query.ToArray();
            }
        }

        public ShelterDetail GetShelterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shelters
                        .Single(e => e.ShelterId == id);
                return
                    new ShelterDetail
                    {
                        ShelterId = entity.ShelterId,
                        ShelterName = entity.ShelterName,
                        ShelterAddress = entity.ShelterAddress,
                        ShelterPhoneNumber = entity.ShelterPhoneNumber

                    };
            }
        }
        public bool UpdateShelter (ShelterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shelters
                    .Single(e => e.ShelterId == model.ShelterId);
                entity.ShelterName = model.ShelterName;
                entity.ShelterAddress = model.ShelterAddress;
                entity.ShelterPhoneNumber = model.ShelterPhoneNumber;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteShelter(int shelterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shelters
                    .Single(e => e.ShelterId == shelterId);
                ctx.Shelters.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }


    }

}

