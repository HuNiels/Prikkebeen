using System;

namespace Acupunctuur.Models {
    public class ReservationExtended : Reservation {
        public ReservationStatus Status { get; set; }
    }
}
