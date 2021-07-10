﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publico.Models
{
    public class AppUser : IdentityUser<long>
    {
        public AppUser()
        {
            Messages = new HashSet<Message>();
        }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
