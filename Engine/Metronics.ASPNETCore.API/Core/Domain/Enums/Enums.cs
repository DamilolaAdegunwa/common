using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Core.Domain.Enums
{
    public enum DriverStatus
    {
        Idle = 0,
        OnAJourney = 1,
        Suspended = 2,
        OnLeave = 3,
        Dismissal = 4,
        Decease = 5,
        Started = 6
    }
    public enum DriverType
    {
        Permanent = 0,
        Handover = 1,
        Owner = 2,
        Virtual = 3
    }
    public enum TransactionType
    {
        Debit = 0,
        Credit = 1,
        WalletUpdate = 2,
        WalletDeduction = 3
    }
    public enum PayTypeDescription
    {
        Bonus = 0,
        Fine = 1,
        Lateness = 2,
        DrunkDriving = 3,
        Recklesness = 4,
        SalaryPayment = 5,
        WalletUpdate = 6,
        WalletDeduction = 7,
        MTU = 8,
        Part = 9,
        Transload = 10,
        Loan = 11,
    }
    public enum TransactionStatus
    {
        Captured = 0,
        Verified = 1,
        Approved = 2,
        Default = 3,
        Others = 4
    }
}
