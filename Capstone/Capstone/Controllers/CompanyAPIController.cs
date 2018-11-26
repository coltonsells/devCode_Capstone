using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Data;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class CompanyAPIController : ApiControllerAttribute
    {
        DataAccessLayer objData = new DataAccessLayer();
        private readonly ApplicationDbContext _context;

        public CompanyAPIController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/Company/Index")]
        public IEnumerable<Company> Index()
        {
            var comp = _context.Companies.ToList();
            return comp;
        }

        [HttpPost]
        [Route("api/Company/Create")]
        public int Create(Company comp)
        {
            return objData.AddCompany(comp);
        }

        [HttpPut]
        [Route("api/Company/Edit")]
        public int Edit(Company comp)
        {
            return objData.UpdateCompany(comp);
        }

        [HttpDelete]
        [Route("api/Company/Delete/{id}")]
        public int Delete(string id)
        {
            return objData.DeleteEmployee(id);
        }
    }
}