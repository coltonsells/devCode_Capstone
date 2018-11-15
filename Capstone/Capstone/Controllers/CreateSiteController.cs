using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Data;
using Capstone.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class CreateSiteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreateSiteController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CreateSite
        public ActionResult Index(string id)
        {
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            ViewData["CompanyId"] = id;
            ViewData["Theme"] = "Bootstrap.css";
            return View(comp);
        }

        [HttpPost]
        public ActionResult Index(IFormCollection form)
        {
            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            company.Name = form["Name"];
            company.Street = form["Street"];
            company.City = form["City"];
            company.State = form["State"];
            company.Zip = form["Zip"];
            company.Type = form["Type"];
            _context.SaveChanges();
            return RedirectToAction("CreateStandardFeaturesStart");
        }

        // GET: CreateSite/Details/5
        public ActionResult CreateStandardFeaturesStart()
        {
            ViewData["Theme"] = "Bootstrap.css";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateStandardFeaturesStart(IFormCollection form, IFormFile file)
        {
            var comp = _context.Companies.Where(x => x.Id == (string)ViewData["CompanyId"]).FirstOrDefault();
            Image img = new Image();
            img = await StorePicture(img, comp, file);


            
            return View();
        }

        // GET: CreateSite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateSite/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateSite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreateSite/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateSite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateSite/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private async Task<Image> StorePicture(Image img, Company comp, IFormFile picture)
        {
            if (picture != null)
            {
                using (var stream = new MemoryStream())
                {
                    await picture.CopyToAsync(stream);
                    img.ImagePath = stream.ToArray();
                    img.companyId = comp.Id;
                }
            }

            return img;
        }
    }
}