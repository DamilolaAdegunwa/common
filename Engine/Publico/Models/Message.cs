using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Publico.Models
{
    public class Message
    {
        public long Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTimeOffset When { get; set; }
        public long UserId { get; set; }
        public virtual AppUser Sender { get; set; }
    }
}
