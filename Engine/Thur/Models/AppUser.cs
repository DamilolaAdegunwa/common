using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Thur.Models
{
    public class AppUser : IdentityUser<long>
    {
        public virtual ICollection<Message> Messages { get; set; }
    }
}
