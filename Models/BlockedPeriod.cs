using System;

namespace Acupunctuur.Models {
    public class BlockedPeriod {
        public int Id { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public string Description { get; set; }
        public string CustomerMessage { get; set; }
    }
}
