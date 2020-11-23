using System;
using System.Collections.Generic;

namespace Acupunctuur.Models {
    public class ScheduleInfo {
        public DateTime PreviousDay { get; set; }
        public DateTime NextDay { get; set; }
        public string CustomerMessage { get; set; }
        public IList<TimeslotJson> Timeslots { get; set; }
    }
}
