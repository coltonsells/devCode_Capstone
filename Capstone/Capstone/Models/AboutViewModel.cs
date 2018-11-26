using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class AboutViewModel
    {
        public Company Comp { get; set; }
        public About About { get; set; }
        public AboutContainer Container { get; set; }
        public List<AboutContainer> Containers { get; set; }
        public string UserId { get; set; }
    }
}
