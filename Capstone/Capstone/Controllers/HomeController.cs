using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.Data;
using Microsoft.AspNet.Identity;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (User.IsInRole("Company Account"))
            {
                var completeCheck = _context.Companies.Where(x => x.CreatorId == User.Identity.GetUserId()).FirstOrDefault();
                if(completeCheck.SetupComplete == true)
                {
                    return RedirectToAction("HomePage", "CompanyHome", new { id = completeCheck.Id});
                }
                else
                {
                    return RedirectToAction("Index", "CreateSite", new { id = completeCheck.Id });
                }
            }
            else
            {
                return View();

            }
        }

        

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
