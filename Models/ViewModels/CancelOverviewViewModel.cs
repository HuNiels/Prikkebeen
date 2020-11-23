using System.Collections.Generic;

namespace Acupunctuur.Models {
    public class CancelOverviewViewModel : PageViewModel {
        public IList<LateCancellationInfo> LateCancellations { get; set; }
    }
}
