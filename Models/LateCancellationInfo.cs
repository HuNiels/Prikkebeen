using System;

namespace Acupunctuur.Models {
    public class LateCancellationInfo {
        public int CancellationId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public Timeslot Timeslot { get; set; }
        public CancelStatus Status { get; set; }
    }
}
