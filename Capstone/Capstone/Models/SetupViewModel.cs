using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class SetupViewModel
    {
        public Company Comp { get; set; }
        public Home Home { get; set; }
        public About About { get; set; }
        public Contact Contact { get; set; } 
        public Scheduler Scheduler { get; set; }
    }
}
