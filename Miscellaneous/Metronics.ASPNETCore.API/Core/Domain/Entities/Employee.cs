using Metronics.ASPNETCore.API.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Core.Domain.Entities
{
    public class Employee : FullEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
