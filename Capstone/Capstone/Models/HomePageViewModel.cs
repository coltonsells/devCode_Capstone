using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class HomePageViewModel
    {
        public string UserId { get; set; }
        public Company Comp { get; set; }
        public Home Home { get; set; }
        public HomeContainer Container { get; set; }
        public List<HomeContainer> Containers { get; set; }
        public Image Image { get; set; }
        public HomeJumbo Jumbo { get; set; }
    }
}
