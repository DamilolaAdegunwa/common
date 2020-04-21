using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Core.Domain.DTOs
{
    public class DateModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Keyword { get; set; }
        //public BookingTypes BookingType { get; set; }
        public int Id { get; set; }
        //public VehicleStatus Status { get; set; }
        public string Code { get; set; }
    }
}
