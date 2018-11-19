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
    public class CompanyContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ContactInitialSetup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactInitialSetup(IFormCollection form)
        {
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var contact = _context.ContactPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            contact.NavTag = form["navTag"];
            _context.SaveChanges();
            return RedirectToAction("ContactContainerSetup");
        }

        public IActionResult ContactContainerSetup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactContainerSetup(string container)
        {
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var contact = _context.ContactPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            int amount = Int32.Parse(container);
            contact.ContainerType = container;
            contact.ContainerAmount = amount;
            _context.SaveChanges();
            return RedirectToAction("ContactContainerContent");
        }
    
        
        public IActionResult ContactContainerContent()
        {
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var contact = _context.ContactPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            List<ContactContainer> containers = new List<ContactContainer>();
            for (int i = 0; i < contact.ContainerAmount; i++)
            {
                ContactContainer newCont = new ContactContainer()
                {
                    ContactId = contact.Id,
                    DivSection = i + 1
                };
                containers.Add(newCont);
            }
            return View(containers);
        }

        [HttpPost]
        public async Task<IActionResult> ContactContainerContent(IFormCollection form, IFormFile pic1, IFormFile pic2, IFormFile pic3)
        {
            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var contact = _context.ContactPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            if (pic1 != null || pic2 != null || pic3 != null)
            {
                if (pic1 != null)
                {
                    ContactContainer newImage = new ContactContainer();
                    newImage = await StoreContactPicture(newImage, contact, pic1);
                    newImage.DivSection = 1;
                    newImage.ContactId = contact.Id;
                    _context.ContactContainers.Add(newImage);
                }
                if (pic2 != null)
                {
                    ContactContainer newImage = new ContactContainer();
                    newImage = await StoreContactPicture(newImage, contact, pic2);
                    newImage.DivSection = 2;
                    newImage.ContactId = contact.Id;
                    _context.ContactContainers.Add(newImage);
                }
                if (pic3 != null)
                {
                    ContactContainer newImage = new ContactContainer();
                    newImage = await StoreContactPicture(newImage, contact, pic3);
                    newImage.DivSection = 3;
                    newImage.ContactId = contact.Id;
                    _context.ContactContainers.Add(newImage);
                }

            }
            for (int i = 0; i < contact.ContainerAmount; i++)
            {
                string container = (i + 1).ToString();
                string check = "textArea+" + container;
                if (form[check] != "")
                {
                    string align = "Alignment+" + container;
                    string color = "Color+" + container;
                    string font = "Font+" + container;
                    string size = "Size+" + container;
                    string BgColor = "BackgroundColor+" + container;
                    ContactContainer newText = new ContactContainer();
                    newText.Text = form[check];
                    newText.Align = form[align];
                    newText.Color = form[color];
                    newText.Font = form[font];
                    newText.BgColor = form[BgColor];
                    newText.FontSize = form[size];
                    newText.DivSection = (i + 1);
                    newText.ContactId = contact.Id;
                    _context.ContactContainers.Add(newText);
                }
            }
         company.ContactSetupComplete = true;
         company.SetupComplete = true;
         _context.SaveChanges();
         return RedirectToAction("HomePage", "CompanyHome");   
    }
    
    public IActionResult ContactPage()
        {
            ViewData["Theme"] = "bootstrap.css";
            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            About about = new About() { NavTag = "none" };
            Contact contact = new Contact() { NavTag = "none" };
            if (company.About)
            {
                about = _context.AboutPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            if (company.Contact)
            {
                contact = _context.ContactPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            }
            ViewData["homeNav"] = home.NavTag;
            ViewData["aboutNav"] = about.NavTag;
            ViewData["contactNav"] = contact.NavTag;
            List<ContactContainer> containers = _context.ContactContainers.Where(x => x.ContactId == contact.Id).ToList();
            containers = containers.OrderBy(x => x.DivSection).ToList();
            ContactViewModel ViewModel = new ContactViewModel()
            {
                Comp = company,
                Contact = contact,
                Containers = containers
            };
            return View(ViewModel);
        }
     
    private async Task<ContactContainer> StoreContactPicture(ContactContainer img, Contact contact, IFormFile picture)
    {
        if (picture != null)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                await picture.CopyToAsync(stream);
                img.Image = stream.ToArray();
                img.ContactId = contact.Id;
            }
        }

        return img;
    }




















    // GET: CompanyContact
    public ActionResult Index()
        {
            return View();
        }

        // GET: CompanyContact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyContact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyContact/Create
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

        // GET: CompanyContact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyContact/Edit/5
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

        // GET: CompanyContact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyContact/Delete/5
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