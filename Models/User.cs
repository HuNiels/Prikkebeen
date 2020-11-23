using System.Collections.Generic;

namespace Acupunctuur.Models {
    public class User {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public bool NewUser { get; set; }
        public bool Admin { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public UserPrivacyInfo UserPrivacyInfo { get; set; }
    }
}
