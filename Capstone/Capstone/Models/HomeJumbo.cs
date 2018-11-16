using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class HomeJumbo
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("company")]
        public string CompanyId { get; set; }
        public Company company { get; set; }
        public string Text { get; set; }
        public string TextAlign { get; set; }
        public string TextFont { get; set; }
        public string TextColor { get; set; }
    }
}
