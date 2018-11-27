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
            HomePageViewModel ViewModel = new HomePageViewModel()
            {
                Containers = containers,
                Comp = company,
                Home = home
            };
            TempData["containerCount"] = loops.ToString();
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> HomeContainerContent(IFormCollection form, IFormFile pic1, IFormFile pic2, IFormFile pic3 )
        {
            int amount = Int32.Parse((string)TempData["containerCount"]);

            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            if (form["map+1"]=="on" || form["map+2"] == "on" || form["map+3"] == "on")
            {
                if(form["map+1"] == "on")
                {
                    HomeContainer newMap = new HomeContainer();
                    newMap.DivSection = 1;
                    newMap.HomeId = home.Id;
                    newMap.Maps = true;
                    _context.HomeContainers.Add(newMap);
                }
                if (form["map+2"] == "on")
                {
                    HomeContainer newMap = new HomeContainer();
                    newMap.DivSection = 2;
                    newMap.HomeId = home.Id;
                    newMap.Maps = true;
                    _context.HomeContainers.Add(newMap);
                }
                if (form["map+3"] == "on")
                {
                    HomeContainer newMap = new HomeContainer();
                    newMap.DivSection = 3;
                    newMap.HomeId = home.Id;
                    newMap.Maps = true;
                    _context.HomeContainers.Add(newMap);
                }
            }
            if (form["twitter+1"] == "on" || form["twitter+2"] == "on" || form["twitter+3"] == "on")
            {
                if (form["twitter+1"] == "on")
                {
                    HomeContainer newMap = new HomeContainer();
                    newMap.DivSection = 1;
                    newMap.HomeId = home.Id;
                    newMap.Twitter = true;
                    _context.HomeContainers.Add(newMap);
                }
                if (form["twitter+2"] == "on")
                {
                    HomeContainer newMap = new HomeContainer();
                    newMap.DivSection = 2;
                    newMap.HomeId = home.Id;
                    newMap.Twitter = true;
                    _context.HomeContainers.Add(newMap);
                }
                if (form["twitter+3"] == "on")
                {
                    HomeContainer newMap = new HomeContainer();
                    newMap.DivSection = 3;
                    newMap.HomeId = home.Id;
                    newMap.Twitter = true;
                    _context.HomeContainers.Add(newMap);
                }
            }
            if (pic1 != null || pic2 != null || pic3 != null)
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
                    newText.BgColor = form[BgColor];
                    newText.FontSize = form[size];
                    newText.DivSection = (i + 1);
                    newText.HomeId = home.Id;
                    _context.HomeContainers.Add(newText);
                }
            }
            company.HomeSetupComplete = true;
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
                return RedirectToAction("HomePage", new { id = company.Id });
            }
        }

        public IActionResult HomePage(string id)
        {
            ViewData["CompanyId"] = id;
            var company = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            ViewData["Theme"] = company.Theme;
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            var image = _context.Images.Where(x => x.companyId == company.Id).FirstOrDefault();
            var jumbo = _context.HomeJumbos.Where(x => x.CompanyId == company.Id).FirstOrDefault();
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
            List<HomeContainer> containers = _context.HomeContainers.Where(x => x.HomeId == home.Id).ToList();
            containers = containers.OrderBy(x => x.DivSection).ToList();
            HomePageViewModel ViewModel = new HomePageViewModel()
            {
                UserId = User.Identity.GetUserId(),
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


        

        public async Task<IActionResult> EditHomeContainer(string id, int divSection)
        {
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            ViewData["Theme"] = comp.Theme;
            var home = _context.HomePages.Where(x => x.CompanyId == id).FirstOrDefault();
            var container = _context.HomeContainers.Where(x => x.HomeId == home.Id).Where(x => x.DivSection == divSection).FirstOrDefault();
            HomePageViewModel ViewModel = new HomePageViewModel()
            {
                Home = home,
                Container = container,
                Comp = comp
            };
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditHomeContainer(IFormCollection form, IFormFile pic1, IFormFile pic2, IFormFile pic3)
        {
            var divSection = form["Container.DivSection"];
            var company = _context.Companies.Where(x => x.Id == form["Comp.Id"]).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == company.Id).FirstOrDefault();
            var container = _context.HomeContainers.Where(x => x.Id == form["Container.Id"]).FirstOrDefault();
            container.Maps = false;
            container.Twitter = false;
            container.Text = null;
            container.Image = null;
            if (form["map+" + divSection] == "on")
            {
                container.Maps = true;
            }
           else if (form["twitter+" + divSection] == "on")
            {
                container.Twitter = true;
                  
            }
           else if (pic1 != null)
            {   
                container = await StoreHomePicture(container, home, pic1);
            }
            else if (pic2 != null)
            {
                container = await StoreHomePicture(container, home, pic2);
            }
            else if (pic3 != null)
            {
                container = await StoreHomePicture(container, home, pic3);
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
            return RedirectToAction("HomePage", new { id = company.Id });
            
         
        }

        public IActionResult ChangeTheme(string theme)
        {
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            comp.Theme = theme;
            _context.SaveChanges();
            return RedirectToAction("HomePage", new { id = comp.Id });
        }
    }
}