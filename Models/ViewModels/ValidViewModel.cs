using System;

namespace Acupunctuur.Models {
    public class ValidViewModel : PageViewModel {
        // 0 is no error. 1 is the first error
        public int Error { set; get; }
    }
}
