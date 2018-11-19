using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Data;
using Capstone.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class CompanyAboutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyAboutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AboutInitialSetup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutInitialSetup(IFormCollection form)
        {
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var about = _context.AboutPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            about.NavTag = form["navTag"];
            _context.SaveChanges();
            return RedirectToAction("AboutContainerSetup");
        }

        public IActionResult AboutContainerSetup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutContainerSetup(string container)
        {
            return View();
        }



















        // GET: CompanyAbout
        public ActionResult Index()
        {
            return View();
        }

        // GET: CompanyAbout/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyAbout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyAbout/Create
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

        // GET: CompanyAbout/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyAbout/Edit/5
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

        // GET: CompanyAbout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyAbout/Delete/5
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
    }
}