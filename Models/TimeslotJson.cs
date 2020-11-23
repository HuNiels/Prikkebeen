using System;

namespace Acupunctuur.Models {
    public class TimeslotJson {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool Available { get; set; }
        public bool CurrentUser { get; set; }
    }
}
