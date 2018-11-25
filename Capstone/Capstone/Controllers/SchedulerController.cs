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
    public class SchedulerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Scheduler
        public ActionResult Index(string id)
        {
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            var userId = User.Identity.GetUserId();
            if(User.IsInRole("Company Account"))
            {
                if (userId == comp.CreatorId)
                {
                    return RedirectToAction("CompanyView", new { id = comp.Id});
                }
                else
                {
                    return RedirectToAction("AccessDenied", new { id = comp.Id});
                }
            }
            else
            {
                return RedirectToAction("CustomerView", new { id = comp.Id});
            }
        }

        public IActionResult CompanyView(string id)
        {
            var company = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            About about = new About() { NavTag = "none" };
            Contact contact = new Contact() { NavTag = "none" };
            Scheduler sched = new Scheduler() { NavTag = "none" };
            if (company.About)
            {
                about = _context.AboutPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            if (company.Contact)
            {
                contact = _context.ContactPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            if (company.Scheduler)
            {
                sched = _context.SchedulePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            ViewData["homeNav"] = home.NavTag;
            ViewData["aboutNav"] = about.NavTag;
            ViewData["contactNav"] = contact.NavTag;
            ViewData["schedulerNav"] = sched.NavTag;
            var events = _context.Events.Where(x => x.CompanyId == company.Id).ToList();
            SchedulerViewModel ViewModel = new SchedulerViewModel()
            {
                Comp = company,
                Events = events
            };
            return View(ViewModel);
        }
        public IActionResult AccessDenied(string id)
        {
            var company = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            About about = new About() { NavTag = "none" };
            Contact contact = new Contact() { NavTag = "none" };
            Scheduler sched = new Scheduler() { NavTag = "none" };
            if (company.About)
            {
                about = _context.AboutPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            if (company.Contact)
            {
                contact = _context.ContactPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            if (company.Scheduler)
            {
                sched = _context.SchedulePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            ViewData["homeNav"] = home.NavTag;
            ViewData["aboutNav"] = about.NavTag;
            ViewData["contactNav"] = contact.NavTag;
            ViewData["schedulerNav"] = sched.NavTag;
            return View();
        }
        public IActionResult CustomerView(string id)
        {
            ViewData["CompanyId"] = id;
            ViewData["Theme"] = "bootstrap.css";
            var company = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            About about = new About() { NavTag = "none" };
            Contact contact = new Contact() { NavTag = "none" };
            Scheduler sched = new Scheduler() { NavTag = "none" };
            if (company.About)
            {
                about = _context.AboutPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            if (company.Contact)
            {
                contact = _context.ContactPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            if (company.Scheduler)
            {
                sched = _context.SchedulePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            ViewData["homeNav"] = home.NavTag;
            ViewData["aboutNav"] = about.NavTag;
            ViewData["contactNav"] = contact.NavTag;
            ViewData["schedulerNav"] = sched.NavTag;
            var cust = _context.Customers.Where(x => x.UserId == User.Identity.GetUserId()).FirstOrDefault();
            var events = _context.Events.Where(x => x.CustomerId == User.Identity.GetUserId()).ToList();
            SchedulerViewModel ViewModel = new SchedulerViewModel()
            {
                Comp = company,
                Events = events,
                Customer = cust,
                Scheduler = sched

            };
            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult CustomerView(IFormCollection form)
        {
            var comp = _context.Companies.Where(x => x.Id == form["Comp.Id"]).FirstOrDefault();
            var sched = _context.SchedulePages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            var cust = _context.Customers.Where(x => x.UserId == User.Identity.GetUserId()).FirstOrDefault();
            Events newEvent = new Events()
            {
                CompanyId = comp.Id,
                CustomerId = cust.Id,
                FirstName = form["Event.FirstName"],
                LastName = form["Event.LastName"],
                StartTime = DateTime.Parse(form["Event.StartTime"]),
                Notes = form["Event.Notes"]
            };
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return RedirectToAction("CustomerView", new { id = comp.Id});
        }

        public IActionResult CompanyView()
        {
            return View();
        }
        // GET: Scheduler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Scheduler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scheduler/Create
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

        // GET: Scheduler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Scheduler/Edit/5
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

        // GET: Scheduler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Scheduler/Delete/5
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