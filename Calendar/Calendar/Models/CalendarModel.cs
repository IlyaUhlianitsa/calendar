using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class CalendarModel
    {
        public string Title { get; set; }

        public int StartDayOfWeak { get; set; }

        public int EndDay { get; set; }
    }
}
