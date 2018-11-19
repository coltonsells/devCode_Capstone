using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ContactContainer
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("contact")]
        public string ContactId { get; set; }
        public Contact contact { get; set; }
        public int DivSection { get; set; }
        public byte[] Image { get; set; }
        public string Text { get; set; }
        public string Align { get; set; }
        public string Color { get; set; }
        public string Font { get; set; }
        public string FontSize { get; set; }
        public string BgColor { get; set; }
    }
}
