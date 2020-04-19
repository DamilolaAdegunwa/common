using Metronics.ASPNETCore.API.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Data.efCore.Context
{
    public class BaseDbContext : IdentityDbContext<User, Role, long>
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
