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
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var about = _context.AboutPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            int amount = 0;
            about.ContainerType = container;

            switch (container)
            {
                case "1":
                    amount = 1;
                    break;
                case "2":
                    amount = 2;
                    break;
                case "3":
                    amount = 3;
                    break;
                case "4":
                    amount = 3;
                    break;
                case "5":
                    amount = 3;
                    break;
                case "6":
                    amount = 4;
                    break;
                case "7":
                    amount = 4;
                    break;
                case "8":
                    amount = 4;
                    break;
                case "9":
                    amount = 5;
                    break;
                case "10":
                    amount = 6;
                    break;
            }
            about.ContainerAmount = amount;
            _context.SaveChanges();
            return RedirectToAction("AboutContainerContent");
        }


        public IActionResult AboutContainerContent()
        {
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var about = _context.AboutPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            List<AboutContainer> containers = new List<AboutContainer>();
            for (int i = 0; i < about.ContainerAmount; i++)
            {
                AboutContainer newCont = new AboutContainer()
                {
                    AboutId = about.Id,
                    DivSection = i + 1
                };
                containers.Add(newCont);
            }
            AboutViewModel ViewModel = new AboutViewModel()
            {
                Comp = comp,
                About = about,
                Containers = containers
            };
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AboutContainerContent(IFormCollection form, IFormFile pic1, IFormFile pic2, IFormFile pic3, IFormFile pic4, IFormFile pic5, IFormFile pic6)
        {
            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var about = _context.AboutPages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            if (form["map+1"] == "on" || form["map+2"] == "on" || form["map+3"] == "on" || form["map+4"] == "on" || form["map+5"] == "on" || form["map+6"] == "on")
            {
                if (form["map+1"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 1;
                    newMap.AboutId = about.Id;
                    newMap.Maps = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["map+2"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 2;
                    newMap.AboutId = about.Id;
                    newMap.Maps = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["map+3"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 3;
                    newMap.AboutId = about.Id;
                    newMap.Maps = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["map+4"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 4;
                    newMap.AboutId = about.Id;
                    newMap.Maps = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["map+5"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 5;
                    newMap.AboutId = about.Id;
                    newMap.Maps = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["map+6"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 6;
                    newMap.AboutId = about.Id;
                    newMap.Maps = true;
                    _context.AboutContainers.Add(newMap);
                }
            }
            if (form["twitter+1"] == "on" || form["twitter+2"] == "on" || form["twitter+3"] == "on" || form["twitter+4"] == "on" || form["twitter+5"] == "on" || form["twitter+6"] == "on")
            {
                if (form["twitter+1"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 1;
                    newMap.AboutId = about.Id;
                    newMap.Twitter = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["twitter+2"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 2;
                    newMap.AboutId = about.Id;
                    newMap.Twitter = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["twitter+3"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 3;
                    newMap.AboutId = about.Id;
                    newMap.Twitter = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["twitter+4"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 4;
                    newMap.AboutId = about.Id;
                    newMap.Twitter = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["twitter+5"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 5;
                    newMap.AboutId = about.Id;
                    newMap.Twitter = true;
                    _context.AboutContainers.Add(newMap);
                }
                if (form["twitter+6"] == "on")
                {
                    AboutContainer newMap = new AboutContainer();
                    newMap.DivSection = 6;
                    newMap.AboutId = about.Id;
                    newMap.Twitter = true;
                    _context.AboutContainers.Add(newMap);
                }
            }
            if (pic1 != null || pic2 != null || pic3 != null || pic4 != null || pic5 != null || pic6 != null)
            {
                if (pic1 != null)
                {
                    AboutContainer newImage = new AboutContainer();
                    newImage = await StoreAboutPicture(newImage, about, pic1);
                    newImage.DivSection = 1;
                    newImage.AboutId = about.Id;
                    _context.AboutContainers.Add(newImage);
                }
                if (pic2 != null)
                {
                    AboutContainer newImage = new AboutContainer();
                    newImage = await StoreAboutPicture(newImage, about, pic2);
                    newImage.DivSection = 2;
                    newImage.AboutId = about.Id;
                    _context.AboutContainers.Add(newImage);
                }
                if (pic3 != null)
                {
                    AboutContainer newImage = new AboutContainer();
                    newImage = await StoreAboutPicture(newImage, about, pic3);
                    newImage.DivSection = 3;
                    newImage.AboutId = about.Id;
                    _context.AboutContainers.Add(newImage);
                }
                if (pic4 != null)
                {
                    AboutContainer newImage = new AboutContainer();
                    newImage = await StoreAboutPicture(newImage, about, pic4);
                    newImage.DivSection = 4;
                    newImage.AboutId = about.Id;
                    _context.AboutContainers.Add(newImage);
                }
                if (pic5 != null)
                {
                    AboutContainer newImage = new AboutContainer();
                    newImage = await StoreAboutPicture(newImage, about, pic5);
                    newImage.DivSection = 5;
                    newImage.AboutId = about.Id;
                    _context.AboutContainers.Add(newImage);
                }
                if (pic6 != null)
                {
                    AboutContainer newImage = new AboutContainer();
                    newImage = await StoreAboutPicture(newImage, about, pic6);
                    newImage.DivSection = 6;
                    newImage.AboutId = about.Id;
                    _context.AboutContainers.Add(newImage);
                }
            }
            for (int i = 0; i < about.ContainerAmount; i++)
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
                    AboutContainer newText = new AboutContainer();
                    newText.Text = form[check];
                    newText.Align = form[align];
                    newText.Color = form[color];
                    newText.Font = form[font];
                    newText.BgColor = form[BgColor];
                    newText.FontSize = form[size];
                    newText.DivSection = (i + 1);
                    newText.AboutId = about.Id;
                    _context.AboutContainers.Add(newText);
                }
            }
            company.AboutSetupComplete = true;

            if (company.Contact)
            {
                _context.SaveChanges();
                return RedirectToAction("ContactInitialSetup", "CompanyContact");
            }
            else
            {
                company.SetupComplete = true;
                _context.SaveChanges();
                return RedirectToAction("HomePage", "CompanyHome", new { id = company.Id});
            }
    }

    public IActionResult AboutPage(string id)
        {
            ViewData["CompanyId"] = id;
            ViewData["Theme"] = "bootstrap.css";
            var company = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
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
            List<AboutContainer> containers = _context.AboutContainers.Where(x => x.AboutId == about.Id).ToList();
            containers = containers.OrderBy(x => x.DivSection).ToList();
            AboutViewModel ViewModel = new AboutViewModel()
            {
                Comp = company,
                About = about,
                Containers = containers
            };
            return View(ViewModel);
        }

    
    private async Task<AboutContainer> StoreAboutPicture(AboutContainer img, About about, IFormFile picture)
    {
        if (picture != null)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                await picture.CopyToAsync(stream);
                img.Image = stream.ToArray();
                img.AboutId = about.Id;
            }
        }

        return img;
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