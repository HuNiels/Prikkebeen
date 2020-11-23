using System.Collections.Generic;

namespace Acupunctuur.Models {
    public class PageViewModel {
        public IList<Page> Pages { get; set; }
        public Page CurrentPage { get; set; }
        public bool Dynamic { get; set; }
    }
}
