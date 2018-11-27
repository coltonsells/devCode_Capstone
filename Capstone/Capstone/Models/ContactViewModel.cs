using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ContactViewModel
    {
        public Company Comp { get; set; }
        public Contact Contact { get; set; }
        public ContactContainer Container { get; set; }
        public List<ContactContainer> Containers { get; set; }
        public string UserId { get; set; }
    }
}
