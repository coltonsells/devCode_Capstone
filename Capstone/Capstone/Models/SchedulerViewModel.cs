using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class SchedulerViewModel
    {
        public Company Comp { get; set; }
        public Customer Customer { get; set; }
        public Scheduler Scheduler { get; set; }
        public List<Events> Events { get; set; }
        public Events Event { get; set; }
    }
}
