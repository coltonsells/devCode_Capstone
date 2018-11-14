using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class StandardFeatures
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public Company Company { get; set; }
        public bool Home { get; set; }
        public bool About { get; set; }
        public bool Contact { get; set; }
    }
}
