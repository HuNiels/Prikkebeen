using System;

namespace Acupunctuur.Models {
    public class ReservationViewModel : PageViewModel {
        public DateTime SelectedDay { get; set; }
        public DateTime LastDay { get; set; }
        public bool NewUser { get; set; }
        public bool HasAReservation { get; set; }
        public int Error { get; set; }
    }
}
