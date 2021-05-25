using PetPickr.Data;
using PetPickr.Models;
using PetPickr.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetPickr.Controllers
{
    public class DogController : Controller
    {

        private ApplicationDbContext ctx = new ApplicationDbContext();
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";
            var service = new DogService();
            var dogs = service.GetDogs();

            switch (sortOrder)
            {
                case "name_desc":
                    dogs = dogs.OrderByDescending(s => s.DogName);
                    break;
                case "Price":
                    dogs = dogs.OrderBy(s => s.DogPrice);
                    break;
                case "Price_desc":
                    dogs = dogs.OrderByDescending(s => s.DogPrice);
                    break;
                default:
                    dogs = dogs.OrderBy(s => s.DogName);
                    break;
            }
            return View(dogs.ToList());
        }


        //GET
        [Authorize(Roles = "Admin,Shelter")]
        
        public ActionResult Create()
        {
            using (var ctx = new ApplicationDbContext())
            {
                    ViewBag.ShelterList = ctx.Shelters.Select
                    (s => new SelectListItem()
                    {
                        Text = s.ShelterName,
                        Value = s.ShelterId.ToString()
                    }
                    ).ToList();
            }
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Shelter")]

        public ActionResult Create(DogCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new DogService();
            if (service.CreateDog(model))
            {
                TempData["SaveResult"] = "Your dog was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Dog could not be added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = new DogService();
            var model = svc.GetDogById(id);
            return View(model);
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ViewBag.ShelterList = ctx.Shelters.Select
                (s => new SelectListItem()
                {
                    Text = s.ShelterName,
                    Value = s.ShelterId.ToString()
                }
                ).ToList();
            }
            var service = new DogService();
            var detail = service.GetDogById(id);
            var model =
                    new DogEdit
                    {
                        DogId= detail.DogId,
                        DogName = detail.DogName,
                        DogBreed = detail.DogBreed,
                        DogSex = detail.DogSex,
                        DogWeight = detail.DogWeight,
                        DogAge = detail.DogAge,
                        DogPrice = detail.DogPrice,
                        DogImage = detail.DogImage,
                        ShelterId = detail.ShelterId

                    };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int id, DogEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DogId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new DogService();

            if (service.UpdateDog(model))
            {
                TempData["SaveResult"] = "Your dog was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your dog could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int id)
        {
            var svc = new DogService();
            var model = svc.GetDogById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult DeletePost(int id)
        {
            var service = new DogService();
            service.DeleteDog(id);
            TempData["SaveResult"] = "Dog deleted.";

            return RedirectToAction("Index");
        }
    }
}