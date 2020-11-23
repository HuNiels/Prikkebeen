using System;
using System.ComponentModel.DataAnnotations;

namespace Acupunctuur.Models
{
    public class Cancellation
    {
        [Key]
        public int Id { get; set; }
        public DateTime CancelDate { get; set; }
        public bool ByAdmin { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public bool Done { get; set; }
        public CancelStatus CancelStatus { get; set; }
    }
}
