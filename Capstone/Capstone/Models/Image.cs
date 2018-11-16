using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Image
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("company")]
        public string companyId { get; set; }
        public Company company { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageByte { get; set; }
    }
}
