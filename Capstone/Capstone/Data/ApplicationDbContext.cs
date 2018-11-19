using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SpecialFeatures> SpecialFeatures { get; set; }
        public DbSet<StandardFeatures> StandardFeatures { get; set; }
        public DbSet<Home> HomePages { get; set; }
        public DbSet<About> AboutPages { get; set; }
        public DbSet<Contact> ContactPages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<HomeJumbo> HomeJumbos { get; set; }
        public DbSet<HomeContentImages> HomeContentImages { get; set; }
        public DbSet<HomeContainer> HomeContainers { get; set; }
        public DbSet<AboutContainer> AboutContainers { get; set; }
        public DbSet<ContactContainer> ContactContainers { get; set; }
    }
}
