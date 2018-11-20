using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Data;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Korzh.EasyQuery.Linq;

namespace Capstone.Controllers
{
    public class SearchController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Search
        public IActionResult Index()
        {
            var Companies = _context.Companies.ToList();
            var Images = _context.Images.ToList();
            SearchViewModel ViewModel = new SearchViewModel()
            {
                Companies = Companies,
                Images = Images
            };

            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            string UserInput = form["UserInput"];
            var Images = _context.Images.ToList();
            var filteredRetail = new List<Company>();
            var filteredService = new List<Company>();
            var filteredManu = new List<Company>();
            var filteredEnter = new List<Company>();
            var filteredResults = new List<Company>();
            var filteredComp = _context.Companies.FullTextSearchQuery(UserInput).ToList();
            List<Company> Companies = new List<Company>();
            if (form["filterRetail"] == "on")
            {
                filteredRetail = filteredComp.Where(x => x.Type == "Retail").ToList();
                filteredResults = AddToList(filteredRetail, filteredResults);
            }
            if (form["filterService"] == "on")
            {
                filteredService = filteredComp.Where(x => x.Type == "Service").ToList();
                filteredResults = AddToList(filteredService, filteredResults);
            }
            if (form["filteredManufactering"] == "on")
            {
                filteredManu = filteredComp.Where(x => x.Type == "Manufacturing").ToList();
                filteredResults = AddToList(filteredManu, filteredResults);
            }
            if (form["filterEntertainment"] == "on")
            {
                filteredEnter = filteredComp.Where(x => x.Type == "Entertainment").ToList();
                filteredResults = AddToList(filteredManu, filteredResults);
            }
           
            SearchViewModel ViewModel = new SearchViewModel()
            {
                Images = Images
            };
            if(form["filterRetail"] == "on"|| form["filterService"] =="on" || form["filteredManufacturing"]=="on" || form["filterEntertainment"] == "on")
            {
                ViewModel.Companies = filteredResults;
            }
            else
            {
                ViewModel.Companies = filteredComp;
            }

            return View(ViewModel);
        }


        public List<Company> AddToList(List<Company> filtered, List<Company> original)
        {
            foreach(var comp in filtered)
            {
                original.Add(comp);
            }
            return original;
        }












        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
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

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
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

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
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