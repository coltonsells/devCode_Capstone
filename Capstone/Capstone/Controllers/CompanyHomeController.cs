using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class CompanyHomeController : Controller
    {
        // GET: CompanyHome
        public IActionResult InitialSetup()
        {
            ViewData["Theme"] = "Bootstrap.css";
            return View();
        }

        [HttpPost]
        public IActionResult InitialSetup(IFormCollection form)
        {
            return View();
        }

        public ActionResult Index(string id)
        {
            ViewData["Theme"] = "Cerulean.css";
            return View();
        }
       

        // GET: CompanyHome/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyHome/Create
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

        // GET: CompanyHome/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyHome/Edit/5
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

        // GET: CompanyHome/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyHome/Delete/5
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