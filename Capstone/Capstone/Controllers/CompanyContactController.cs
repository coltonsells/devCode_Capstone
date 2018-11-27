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
         return RedirectToAction("HomePage", "CompanyHome", new { id = company.Id});   
    }
    
    public IActionResult ContactPage(string id)
        {
            ViewData["CompanyId"] = id;
            var company = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            ViewData["Theme"] = company.Theme;
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
            List<ContactContainer> containers = _context.ContactContainers.Where(x => x.ContactId == contact.Id).ToList();
            containers = containers.OrderBy(x => x.DivSection).ToList();
            ContactViewModel ViewModel = new ContactViewModel()
            {
                Comp = company,
                Contact = contact,
                Containers = containers,
                UserId = User.Identity.GetUserId()
            };
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ContactPage(IFormCollection form)
        {
            var compId = form["Comp.Id"];
            var subject = form["name"] + " Comment";
            var body = form["comments"];
            await Sendgrid.SendMail("coltonsells25@gmail.com", subject, body);
            return RedirectToAction("ContactPage", new { id = compId});
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



 

        public async Task<IActionResult> EditContactContainer(string id, int divSection)
        {
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            ViewData["Theme"] = comp.Theme;
            var contact = _context.ContactPages.Where(x => x.CompanyId == id).FirstOrDefault();
            var container = _context.ContactContainers.Where(x => x.ContactId == contact.Id).Where(x => x.DivSection == divSection).FirstOrDefault();
            ContactViewModel ViewModel = new ContactViewModel()
            {
                Contact = contact,
                Container = container,
                Comp = comp,
                UserId = User.Identity.GetUserId()
            };
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditContactContainer(IFormCollection form, IFormFile pic1, IFormFile pic2, IFormFile pic3)
        {
            var divSection = form["Container.DivSection"];
            var company = _context.Companies.Where(x => x.Id == form["Comp.Id"]).FirstOrDefault();
            var contact = _context.ContactPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            var container = _context.ContactContainers.Where(x => x.Id == form["Container.Id"]).FirstOrDefault();
            container.Text = null;
            container.Image = null;
            
            if (pic1 != null)
            {
                container = await StoreContactPicture(container, contact, pic1);
            }
            else if (pic2 != null)
            {
                container = await StoreContactPicture(container, contact, pic2);
            }
            else if (pic3 != null)
            {
                container = await StoreContactPicture(container, contact, pic3);
            }
            else
            {
                string check = "textArea+" + divSection;
                if (form[check] != "")
                {
                    string align = "Alignment+" + divSection;
                    string color = "Color+" + divSection;
                    string font = "Font+" + divSection;
                    string size = "Size+" + divSection;
                    string BgColor = "BackgroundColor+" + divSection;
                    container.Text = form[check];
                    container.Align = form[align];
                    container.Color = form[color];
                    container.Font = form[font];
                    container.BgColor = form[BgColor];
                    container.FontSize = form[size];
                }
            }
            _context.SaveChanges();
            return RedirectToAction("ContactPage", new { id = company.Id });


        }
    }
}