using Metronics.ASPNETCore.API.Core.Domain.Entities.Common;
using Metronics.ASPNETCore.API.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Core.Domain.Entities
{
    public class WalletTransactionDTO : FullEntity<Guid>//FullAuditedEntity<Guid>
    {
        public TransactionType TransactionType { get; set; }
        public Guid TransactionSourceId { get; set; }
        public string UserId { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal LineBalance { get; set; }
        public int WalletId { get; set; }
        public virtual WalletDTO Wallet { get; set; }
        public string TransDescription { get; set; }
        public PayTypeDescription PayTypeDiscription { get; set; }
        public string TransactedBy { get; set; }
        public bool IsSum { get; set; }
        public bool IsCaptured { get; set; }
        public bool IsVerified { get; set; }
        public string IsVerifiedBy { get; set; }
        public DateTime? IsVerifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string IsApprovedBy { get; set; }
        public DateTime? IsApprovedDate { get; set; }
        public string Code { get; set; }
        public string DriverBankName { get; set; }
        public string DriverBankAccount { get; set; }
        public DateTime CreationTime { get; set; }
        public decimal Balance { get; set; }
        public string DriverName { get; internal set; }
        public string PayTypeDes { get; internal set; }
        public string TransType { get; internal set; }
        public object CreatorUserId { get; internal set; }
        public DateTime LastModificationTime { get; internal set; }
        public int LastModifierUserId { get; internal set; }
    }
}
