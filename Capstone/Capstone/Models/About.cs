using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class About
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("company")]
        public string CompanyId { get; set; }
        public Company company { get; set; }
        public string NavTag { get; set; }
        public bool Paragraph1Check { get; set; }
        public bool Paragraph2Check { get; set; }
        public bool Paragraph3Check { get; set; }
        public string Paragraph1 { get; set; }
        public string Paragraph2 { get; set; }
        public string Paragraph3 { get; set; }
        public bool Maps { get; set; }
        public bool Twitter { get; set; }

    }
}
