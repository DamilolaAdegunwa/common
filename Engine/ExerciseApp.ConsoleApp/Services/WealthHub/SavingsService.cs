using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Services.WealthHub
{
    public class SavingsService
    {
        public void ct()
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddMonths(10);

            //TimeSpan
            var timespan = startDate - endDate;
            var timeSpanInDays = timespan.Days;
            var timeSpanInWeeks = timeSpanInDays / 7;
            var timeSpanInBiWeeks = timeSpanInWeeks / 2;
            var timeSpanInMonths = 10;
            var timespanInYears = 0;
 
        }
    }
}
