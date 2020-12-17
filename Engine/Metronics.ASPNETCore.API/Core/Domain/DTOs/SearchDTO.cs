using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Core.Domain.DTOs
{
    public class SearchDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Driver { get; set; }
        public string PhysicalBusRegistrationNumber { get; set; }
        //public JourneyStatus Status { get; set; }
        public string Code { get; set; }
        //public TransactionStatus TransactionStatus { get; set; }
        public int? DepartureTerminalId { get; set; }
        public Guid Id { get; set; }
    }
}
