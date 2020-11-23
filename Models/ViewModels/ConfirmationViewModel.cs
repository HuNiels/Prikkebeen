
using System;

namespace Acupunctuur.Models {
    public class ConfirmationViewModel : PageViewModel {
        public DateTime ReservedDay { get; set; }
        public Timeslot TimeSlot { get; set; }
    }
}