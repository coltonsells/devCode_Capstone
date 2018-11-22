using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Data;
using Capstone.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

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

        [HttpPost]
        public ActionResult Index(IFormCollection form)
        {
            var company = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            company.Name = form["Name"];
            company.Street = form["Street"];
            company.City = form["City"];
            company.State = form["State"];
            company.Zip = form["Zip"];
            company.Type = form["Type"];
            _context.SaveChanges();
            Home newHome = new Home()
            {
                CompanyId = company.Id,
                Paragraph1Check = false,
                Paragraph2Check = false,
                Paragraph3Check = false
            };
            _context.HomePages.Add(newHome);
            _context.SaveChanges();
            return RedirectToAction("CreateStandardFeaturesStart");
        }

        // GET: CreateSite/Details/5
        public ActionResult CreateStandardFeaturesStart()
        {
            ViewData["Theme"] = "Bootstrap.css";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateStandardFeaturesStart(StandardFeatures features, IFormFile file)
        {
             
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            bool AboutCheck = features.About;
            bool ContactCheck = features.Contact;
            Image img = new Image() { companyId = comp.Id ,ImageByte = null };
            if (file != null)
            {
                img = await StorePicture(img, comp, file);
            }
            _context.Images.Add(img);
            if (AboutCheck)
            {
                comp.About = true;
                comp.AboutSetupComplete = false;
                About newAbout = new About()
                {
                    CompanyId = comp.Id,
                    Twitter = false,
                    Maps = false
                };
                _context.AboutPages.Add(newAbout);
            }
            if (ContactCheck)
            {
                comp.Contact = true;
                comp.ContactSetupComplete = false;
                Contact newContact = new Contact()
                {
                    CompanyId = comp.Id,
                    Twitter = false,
                    Maps = false
                };
                _context.ContactPages.Add(newContact);
            }
            _context.SaveChanges();
            
            return RedirectToAction("PremiumCheck");
        }

        public ActionResult PremiumCheck()
        {
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            ViewData["Theme"] = "Bootstrap.css";
            return View(comp);
        }

        [HttpPost]
        public ActionResult PremiumCheck(IFormCollection form)
        {
            
            return View();
        }
       

        public IActionResult PremiumFeatures(string id)
        {
            TempData["id"] = id;
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            return View(comp);
        }

        [HttpPost]
        public IActionResult PremiumFeatures(IFormCollection form)
        {
            string compId = (string)TempData["id"];
            var comp = _context.Companies.Where(x => x.Id == compId).FirstOrDefault();
            comp.MapChoice = false;
            comp.TwitterChoice = false;
            comp.ContactChoice = false;
            comp.ScheduleChoice = false;
            var an = form["MapChoice"][0];
            if(form["MapChoice"][0] == "true")
            {
                comp.MapChoice = true;
            }
            if(form["TwitterChoice"][0] == "true")
            {
                comp.TwitterChoice = true;
            }
            if(form["ContactChoice"][0] == "true")
            {
                comp.ContactChoice = true;
            }
            if(form["ScheduleChoice"][0] == "true")
            {
                comp.ScheduleChoice = true;
            }
            _context.SaveChanges();
            if (comp.MapChoice)
            {
                return RedirectToAction("SetUpMap", new { id = comp.Id });
            }
            else if (comp.TwitterChoice)
            {
                return RedirectToAction("SetUpTwitter", new { id = comp.Id });
            }
            else if (comp.ContactChoice)
            {
                return RedirectToAction("SetUpContact", new { id = comp.Id });
            }
            else if (comp.ScheduleChoice)
            {
                return RedirectToAction("SetUpSchedule", new { id = comp.Id });
            }
            else if (comp.SetupComplete)
            {
                return RedirectToAction("HomePage", "CompanyHome", new { id = comp.Id});
            }
            else
            {
                return RedirectToAction("InitialSetup", "CompanyHome", new { id = comp.Id });
            }
        }


        public IActionResult SetUpMap(string id)
        {
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            SetupViewModel ViewModel = new SetupViewModel();
            ViewModel.Comp = comp;
            ViewModel.Home = _context.HomePages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            if (comp.About)
            {
                ViewModel.About = _context.AboutPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            }
            if (comp.Contact)
            {
                ViewModel.Contact = _context.ContactPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            }
            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult SetUpMap(IFormCollection form)
        {
            var comp = _context.Companies.Where(x => x.Id == form["Comp.Id"]).FirstOrDefault();
            comp.Street = form["Comp.Street"];
            comp.City = form["Comp.City"];
            comp.State = form["Comp.State"];
            comp.Zip = form["Comp.Zip"];
            var coords = Company.GetLatandLong(comp);
            comp.Lat = coords["lat"];
            comp.Long = coords["lng"];
            if (comp.About)
            {
                var about = _context.AboutPages.Where(x => x.Id == form["About.Id"]).FirstOrDefault();
                if(form["About.Maps"][0] == "true")
                {
                    about.Maps = true;
                }
            }
            if(form["Home.Maps"][0] == "true")
            {
                var home = _context.HomePages.Where(x => x.Id == form["Home.Id"]).FirstOrDefault();
                home.Maps = true;
            }
            _context.SaveChanges();
            if(comp.TwitterChoice == true)
            {
                return RedirectToAction("SetUpTwitter", new { id = comp.Id });
            }
            else if(comp.ContactChoice == true)
            {
                return RedirectToAction("SetUpContact", new { id = comp.Id });
            }
            else if(comp.ScheduleChoice == true)
            {
                return RedirectToAction("SetUpSchedule", new { id = comp.Id });
            }
            else if (comp.SetupComplete)
            {
                return RedirectToAction("HomePage", "CompanyHome", new { id = comp.Id });
            }
            else
            {
                return RedirectToAction("InitialSetup", "CompanyHome", new { id = comp.Id });
            }
        }

        public IActionResult SetUpTwitter(string id)
        {
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            var home = _context.HomePages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            var about = _context.AboutPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            var contact = _context.ContactPages.Where(x => x.CompanyId == comp.Id).FirstOrDefault();
            SetupViewModel ViewModel = new SetupViewModel()
            {
                Comp = comp,
                Home = home,
                About = about,
                Contact = contact
            };
            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult SetUpTwitter(IFormCollection form)
        {
            var comp = _context.Companies.Where(x => x.Id == form["Comp.Id"]).FirstOrDefault();
            comp.Twitter = form["Comp.Twitter"];
            if(form["Home.Twitter"][0] == "true")
            {
                var home = _context.HomePages.Where(x => x.Id == form["Home.Id"]).FirstOrDefault();
                home.Twitter = true;
            }
            if (comp.About)
            {
                if(form["About.Twitter"][0] == "true")
                {
                    var about = _context.AboutPages.Where(x => x.Id == form["About.Id"]).FirstOrDefault();
                    about.Twitter = true;
                }
            }
            _context.SaveChanges();
          
            if (comp.ContactChoice == true)
            {
                return RedirectToAction("SetUpContact", new { id = comp.Id });
            }
            else if (comp.ScheduleChoice == true)
            {
                return RedirectToAction("SetUpSchedule", new { id = comp.Id });
            }
            else if (comp.SetupComplete)
            {
                return RedirectToAction("HomePage", "CompanyHome", new { id = comp.Id });
            }
            else
            {
                return RedirectToAction("InitialSetup", "CompanyHome", new { id = comp.Id });
            }
        }

        public IActionResult SetUpContact(string id)
        {
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            
            return View(comp);
        }

        [HttpPost]
        public IActionResult SetUpContact(IFormCollection form)
        {
            var comp = _context.Companies.Where(x => x.Id == form["Id"]).FirstOrDefault();
            if (comp.ScheduleChoice == true)
            {
                return RedirectToAction("SetUpSchedule", new { id = comp.Id });
            }
            else if (comp.SetupComplete)
            {
                return RedirectToAction("HomePage", "CompanyHome", new { id = comp.Id });
            }
            else
            {
                return RedirectToAction("InitialSetup", "CompanyHome", new { id = comp.Id });
            }
        }

        public IActionResult SetUpSchedule(string id)
        {
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            Scheduler newScheduler = new Scheduler()
            {
                CompanyId = comp.Id,
            };
            _context.SchedulePages.Add(newScheduler);
            _context.SaveChanges();
            SetupViewModel ViewModel = new SetupViewModel()
            {
                Comp = comp,
                Scheduler = newScheduler
            };

            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult SetUpSchedule(IFormCollection form)
        {
            var comp = _context.Companies.Where(x => x.Id == form["Comp.Id"]).FirstOrDefault();
            var sched = _context.SchedulePages.Where(x => x.Id == form["Scheduler.Id"]).FirstOrDefault();
            sched.NavTag = form["navTag"];
            sched.Type = form["Type"];
            _context.SaveChanges();
            return RedirectToAction("InitialSetup","CompanyHome");
        }

        public IActionResult GetCharge(string id)
        {
            return View("StripeCharge");
        }
        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
  
            StripeSettings stripe = new StripeSettings();
            
            var key = stripe.PublishableKey;
            var comp = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 1000,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            _context.SaveChanges();
            return RedirectToAction("ChargeConfirmation", new { id = comp.Id});
        }

        public IActionResult ChargeConfirmation(string id)
        {
            TempData["CompId"] = id;
            var comp = _context.Companies.Where(x => x.Id == id).FirstOrDefault();
            return View(comp);
        }

        [HttpPost]
        public IActionResult ChargeConfirmation()
        {
            string compId = (string)TempData["CompId"];
            return RedirectToAction("PremiumFeatures", new { id = compId });
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
        private async Task<Image> StorePicture(Image img, Company comp, IFormFile picture)
        {
            if (picture != null)
            {
                using (var stream = new MemoryStream())
                {
                    await picture.CopyToAsync(stream);
                    img.ImageByte = stream.ToArray();
                    img.companyId = comp.Id;
                }
            }

            return img;
        }
    }
}