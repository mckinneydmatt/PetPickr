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
        // GET: Dog
        public ActionResult Index()
        {
            var service = new DogService();
            var model = service.GetDogs();
            return View(model);
        }

        //GET
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
                        DogWeight = detail.DogWeight,
                        DogAge = detail.DogAge,
                        DogPrice = detail.DogPrice,

                    };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Delete(int id)
        {
            var svc = new DogService();
            var model = svc.GetDogById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new DogService();
            service.DeleteDog(id);
            TempData["SaveResult"] = "Dog deleted.";

            return RedirectToAction("Index");
        }
    }
}