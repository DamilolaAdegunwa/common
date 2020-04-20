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
}
