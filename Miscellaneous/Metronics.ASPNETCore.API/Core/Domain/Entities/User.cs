using Metronics.ASPNETCore.API.Core.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Core.Domain.Entities
{
    public class User : IdentityUser<long>, IFullEntityWithoutId
    {
        public long? CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public long? DeleterUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
