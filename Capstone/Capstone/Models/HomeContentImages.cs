using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class HomeContentImages
    {
        [Key]
        public string Id { get; set; }
        public string HomeId { get; set; }
        public byte[] Image { get; set; }
    }
}
