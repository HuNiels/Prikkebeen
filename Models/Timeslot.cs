using System;
using System.Collections.Generic;

namespace Acupunctuur.Models {
    public class Timeslot {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool DoubleSlot { get; set; }
        //public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public IList<TimeslotLink> TimeslotBases { get; set; } = new List<TimeslotLink>();
        public IList<TimeslotLink> TimeslotLinks { get; set; } = new List<TimeslotLink>();

        public override bool Equals(object obj)
        {
            return obj is Timeslot timeslot &&
                   Id == timeslot.Id;
        }
    }
}