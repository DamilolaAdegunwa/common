using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thur.Models
{
    public class Message
    {

        [Key]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public string Text{ get; set; }
        public DateTimeOffset When { get; set; }
        public virtual AppUser Sender { get; set; }
        public Message()
        {
            When = DateTimeOffset.Now;
        }
    }
}
