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
    public class CompanyHomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyHomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult InitialSetup()
        {
            ViewData["Theme"] = "Bootstrap.css";
            return View();
        }

        [HttpPost]
        public IActionResult InitialSetup(IFormCollection form)
        {
            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var homePage = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            HomeJumbo newJumbo = new HomeJumbo()
            {
                CompanyId = company.Id,
                Text = form["picText"],
                TextAlign = form["jumboTextAlignment"],
                TextColor = form["jumboColor"],
                TextFont = form["jumboTextFont"],
                TextSize = form["jumboTextSize"]
            };
            homePage.NavTag = form["navTag"];
            _context.HomeJumbos.Add(newJumbo);
            _context.SaveChanges();
            return RedirectToAction("HomeContainerSetup");
        }

        public IActionResult HomeContainerSetup()
        {
            ViewData["Theme"] = "Bootstrap.css";
            return View();
        }

        [HttpPost]
        public IActionResult HomeContainerSetup(string paragraph)
        {
            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            int amount = Int32.Parse(paragraph);
            switch (amount)
            {
                case 1:
                    home.Paragraph1Check = true;
                    break;
                case 2:
                    home.Paragraph1Check = true;
                    home.Paragraph2Check = true;
                    break;
                case 3:
                    home.Paragraph1Check = true;
                    home.Paragraph2Check = true;
                    home.Paragraph3Check = true;
                    break;
            }
            _context.SaveChanges();
            return RedirectToAction("HomeContainerContent");
        }

        public IActionResult HomeContainerContent()
        {
            ViewData["Theme"] = "Bootstrap.css";
            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            List<HomeContainer> containers = new List<HomeContainer>();
            int loops = 0;
            if (home.Paragraph3Check)
            {
                loops = 3;
            }
            else if (home.Paragraph2Check)
            {
                loops = 2;
            }
            else
            {
                loops = 1;
            }

            for(int i = 0; i < loops; i++)
            {
                string name = i.ToString();
                HomeContainer cont = new HomeContainer() { DivSection = (i+1), HomeId = company.Id };
                containers.Add(cont);
            }
            TempData["containerCount"] = loops.ToString();
            return View(containers);
        }

        [HttpPost]
        public async Task<IActionResult> HomeContainerContent(IFormCollection form, IFormFile pic1, IFormFile pic2, IFormFile pic3 )
        {
            int amount = Int32.Parse((string)TempData["containerCount"]);

            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            if(pic1 != null || pic2 != null || pic3 != null)
            {
                if(pic1 != null)
                {
                    HomeContainer newImage = new HomeContainer();
                    newImage = await StoreHomePicture(newImage, home, pic1);
                    newImage.DivSection = 1;
                    newImage.HomeId = home.Id;
                    _context.HomeContainers.Add(newImage);
                }
                if(pic2 != null)
                {
                    HomeContainer newImage = new HomeContainer();
                    newImage = await StoreHomePicture(newImage, home, pic2);
                    newImage.DivSection = 2;
                    newImage.HomeId = home.Id;
                    _context.HomeContainers.Add(newImage);
                }
                if (pic3 != null)
                {
                    HomeContainer newImage = new HomeContainer();
                    newImage = await StoreHomePicture(newImage, home, pic3);
                    newImage.DivSection = 3;
                    newImage.HomeId = home.Id;
                    _context.HomeContainers.Add(newImage);
                }
            }
            for(int i = 0; i < amount; i++)
            {
                string container = (i+1).ToString();
                string check = "textArea+" + container;
                if (form[check] != "")
                {
                    string align = "Alignment+" + container;
                    string color = "Color+" + container;
                    string font = "Font+" + container;
                    string size = "Size+" + container;
                    string BgColor = "BackgroundColor+" + container;
                    HomeContainer newText = new HomeContainer();
                    newText.Text = form[check];
                    newText.Align = form[align];
                    newText.Color = form[color];
                    newText.Font = form[font];
                    newText.Align = form[BgColor];
                    newText.FontSize = form[size];
                    newText.DivSection = (i + 1);
                    newText.HomeId = home.Id;
                    _context.HomeContainers.Add(newText);
                }
            }
            if (company.About)
            {
                _context.SaveChanges();
                return RedirectToAction("AboutInitialSetup", "CompanyAbout");
            }
            else if (company.Contact)
            {
                _context.SaveChanges();
                return RedirectToAction("ContactInitialSetup", "CompanyContact");
            }
            else
            {
                company.SetupComplete = true;
                _context.SaveChanges();
                return RedirectToAction("HomePage");
            }
        }

        public IActionResult HomePage()
        {
            ViewData["Theme"] = "bootstrap.css";
            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            var image = _context.Images.Where(x => x.companyId == company.Id).FirstOrDefault();
            var jumbo = _context.HomeJumbos.Where(x => x.CompanyId == company.Id).FirstOrDefault();
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
            List<HomeContainer> containers = _context.HomeContainers.Where(x => x.HomeId == home.Id).ToList();
            HomePageViewModel ViewModel = new HomePageViewModel()
            {
                Comp = company,
                Home = home,
                Containers = containers,
                Image = image,
                Jumbo = jumbo
            };
            return View(ViewModel);
        }

        private async Task<HomeContainer> StoreHomePicture(HomeContainer img, Home home, IFormFile picture)
        {
            if (picture != null)
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    await picture.CopyToAsync(stream);
                    img.Image = stream.ToArray();
                    img.HomeId = home.Id;
                }
            }

            return img;
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