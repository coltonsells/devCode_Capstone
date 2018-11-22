using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class AboutContainer
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("about")]
        public string AboutId { get; set; }
        public About about { get; set; }
        public int DivSection { get; set; }
        public byte[] Image { get; set; }
        public string Text { get; set; }
        public string Align { get; set; }
        public string Color { get; set; }
        public string Font { get; set; }
        public string FontSize { get; set; }
        public string BgColor { get; set; }
        public bool Maps { get; set; }
        public bool Twitter { get; set; }
    }
}
