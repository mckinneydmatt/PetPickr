using PetPickr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetPickr.Controllers
{
    [Authorize]
    public class ShelterController : Controller
    {
        // GET: Shelter
        public ActionResult Index()
        {
            var model = new ShelterListItem[0];
            return View();
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}