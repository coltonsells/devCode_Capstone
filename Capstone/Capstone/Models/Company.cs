using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Company
    {
        [Key]
        public string Id { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Twitter { get; set; }
        public string Theme { get; set; }
        public string Type { get; set; }
        public bool About { get; set; }
        public bool Contact { get; set; }
        public bool HomeSetupComplete { get; set; }
        public bool ContactSetupComplete { get; set; }
        public bool AboutSetupComplete { get; set; }
        public bool SetupComplete { get; set; }
    }
}
