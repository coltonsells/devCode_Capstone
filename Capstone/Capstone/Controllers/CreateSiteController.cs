using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Data;
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

        // GET: CreateSite/Details/5
        public ActionResult Details(int id)
        {
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
    }
}