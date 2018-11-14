using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Home
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public string Paragraph1 { get; set; }
        public string Paragraph2 { get; set; }
        public string Paragraph3 { get; set; }
        public bool Maps { get; set; }
        public bool Twitter { get; set; }
    }
}
