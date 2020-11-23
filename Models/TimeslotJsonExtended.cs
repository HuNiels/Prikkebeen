using System;

namespace Acupunctuur.Models {
    public class TimeslotJsonExtended : TimeslotJson {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool DoubleSlot { get; set; }
    }
}
