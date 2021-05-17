using PetPickr.Data;
using PetPickr.Models;
using PetPickr.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PetPickr.Controllers
{

    public class CatController : Controller
    {


        // GET: Cat
        public ActionResult Index()
        {
            var service = new CatService();
            var model = service.GetCats();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            using (var ctx = new ApplicationDbContext())
            {

                //List<SelectListItem> listOfShelters = new List<SelectListItem>();
                //foreach (var c in ctx.Shelters)
                //{
                //    listOfShelters.Add(new SelectListItem
                //    {
                //        Text = c.ShelterName,
                //        Value = c.ShelterId.ToString()
                //    });
                //}
                ////ctx.Shelters.Select(s => new SelectListItem() { Text = s.ShelterName, Value = s.ShelterId.ToString() });
                //var shelters = ctx.Shelters.Select(s => new SelectListItem() { Text = s.ShelterName, Value = s.ShelterId.ToString() }).ToList(); // listOfShelters;

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
        public ActionResult Create(CatCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new CatService();
            if (service.CreateCat(model))
            {
                TempData["SaveResult"] = "Your cat was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Cat could not be added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = new CatService();
            var model = svc.GetCatById(id);
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
            var service = new CatService();
            var detail = service.GetCatById(id);
            var model =
                    new CatEdit
                    {
                        CatId = detail.CatId,
                        CatName = detail.CatName,
                        CatSex = detail.CatSex,
                        CatWeight = detail.CatWeight,
                        CatAge = detail.CatAge,
                        CatPrice = detail.CatPrice

                    };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CatEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CatId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new CatService();

            if (service.UpdateCat(model))
            {
                TempData["SaveResult"] = "Your cat was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your cat could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new CatService();
            var model = svc.GetCatById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new CatService();
            service.DeleteCat(id);
            TempData["SaveResult"] = "Cat deleted.";

            return RedirectToAction("Index");
        }
    }
}