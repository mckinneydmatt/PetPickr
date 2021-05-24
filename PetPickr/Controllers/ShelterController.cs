using Microsoft.AspNet.Identity;
using PetPickr.Models;
using PetPickr.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetPickr.Controllers
{

    public class ShelterController : Controller
    {

   

        // GET: Shelter
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
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
        [Authorize(Roles = "Admin")]

        public ActionResult Create(ShelterCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            //var userId = Guid.Parse(User.Identity.GetUserId());
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
                        ShelterPhoneNumber = detail.ShelterPhoneNumber,
                    };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

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
        [Authorize(Roles = "Admin")]

        public ActionResult DeletePost(int id)
        {
            var service = new ShelterService();
            service.DeleteShelter(id);
            TempData["SaveResult"] = "Shelter deleted.";

            return RedirectToAction("Index");
        }
    }
}