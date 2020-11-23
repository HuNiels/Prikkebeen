using System;
using System.ComponentModel.DataAnnotations;

namespace Acupunctuur.Models {
    public class Reservation {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Cancellation? Cancellation { get; set; }
        public User User { get; set; }
        public Timeslot Timeslot { get; set; }
    }
}
