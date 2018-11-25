using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Events
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("customer")]
        public string CustomerId { get; set; }
        public Customer customer { get; set; }
        public string CompanyId { get; set; }
        public DateTime StartTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
    }
}
