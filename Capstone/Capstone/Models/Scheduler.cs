using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Scheduler
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("company")]
        public string CompanyId { get; set; }
        public Company company { get; set; }
        public string NavTag { get; set; }
        public List<Events> Events { get; set; }
        public string Type { get; set; }
    }
}
