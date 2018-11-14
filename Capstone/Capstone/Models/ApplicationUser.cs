using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Name")]
        public string name { get; set; }

        [NotMapped]
        public bool isCompanyPage { get; set; }
    }
}
