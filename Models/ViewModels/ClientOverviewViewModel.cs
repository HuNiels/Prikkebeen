using System.Collections.Generic;

namespace Acupunctuur.Models {
    public class ClientOverviewViewModel : PageViewModel {
        public IList<ReservationExtended> Reservations { get; set; }
    }
}   
