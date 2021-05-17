using PetPickr.Models;
using PetPickr.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetPickr.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ShelterController : Controller
    {

   

        // GET: Shelter
        public ActionResult Index()
        {
            var service = new ShelterService();
            var model = service.GetShelters();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShelterCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new ShelterService();
            if (service.CreateShelter(model))
            {
                TempData["SaveResult"] = "Your shelter was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Shelter could not be created.");
            return View(model);
        } 
        public ActionResult Details(int id)
        {
            var svc = new ShelterService();
            var model = svc.GetShelterById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new ShelterService();
            var detail = service.GetShelterById(id);
            var model =
                    new ShelterEdit
                    {
                        ShelterId = detail.ShelterId,
                        ShelterName = detail.ShelterName,
                        ShelterAddress = detail.ShelterAddress,
                    };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShelterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ShelterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new ShelterService();

            if (service.UpdateShelter(model))
            {
                TempData["SaveResult"] = "Your shelter was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your shelter could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new ShelterService();
            var model = svc.GetShelterById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new ShelterService();
            service.DeleteShelter(id);
            TempData["SaveResult"] = "Shelter deleted.";

            return RedirectToAction("Index");
        }
    }
}