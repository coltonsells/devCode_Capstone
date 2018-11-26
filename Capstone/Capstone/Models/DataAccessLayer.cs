using Capstone.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class DataAccessLayer
    {
        private readonly ApplicationDbContext _context;

        public DataAccessLayer(ApplicationDbContext context)
        {
            _context = context;
        }

        public DataAccessLayer()
        {
        }

        public List<Company> GetAllCompanies()
        {
           
                var comps = _context.Companies.ToList();
                return comps;
            
         
        }

        public int AddCompany(Company comp)
        {
            try
            {
                _context.Companies.Add(comp);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateCompany(Company comp)
        {
            try
            {
                _context.Entry(comp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public Company GetEmployeeData(string id)
        {
            try
            {
                Company comp = _context.Companies.Find(id);
                return comp;
            }
            catch
            {
                throw;
            }
        }

        public int DeleteEmployee(string id)
        {
            try
            {
                Company comp = _context.Companies.Find(id);
                _context.Companies.Remove(comp);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
