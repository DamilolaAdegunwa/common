using Metronics.ASPNETCore.API.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Core.Domain.Entities
{
    public class Wallet : FullEntity
    {
        public string WalletNumber { get; set; }
        public decimal Balance { get; set; }
        public string UserType { get; set; }
        public string UserId { get; set; }
        public bool IsReset { get; set; }
        public string UpdatedBy { get; set; }
        public decimal OldBalance { get; set; }
        public DateTime? WalletLastUpdated { get; set; }
        public DateTime? LastResetDate { get; set; }
    }
}
