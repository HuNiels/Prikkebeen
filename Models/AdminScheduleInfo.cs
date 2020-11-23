using System;
using System.Collections.Generic;

namespace Acupunctuur.Models {
    public class AdminScheduleInfo {
        public DateTime PreviousDay { get; set; }
        public DateTime NextDay { get; set; }
        public IList<TimeslotJsonExtended> Timeslots { get; set; }
    }
}
