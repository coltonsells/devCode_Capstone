using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class SearchViewModel
    {
        public List<Company> Companies { get; set; }
        public List<Image> Images { get; set; }
    }
}
