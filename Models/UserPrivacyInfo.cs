using System;
using System.ComponentModel.DataAnnotations;

namespace Acupunctuur.Models {
    public class UserPrivacyInfo {
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HouseAddress { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is UserPrivacyInfo)
            {
                var upi = (UserPrivacyInfo)obj;
                return
                    LastName.Equals(upi.LastName) &&
                    DateOfBirth.Equals(upi.DateOfBirth) &&
                    HouseAddress.Equals(upi.HouseAddress) &&
                    HouseNumber.Equals(upi.HouseNumber) &&
                    PostCode.Equals(upi.PostCode) &&
                    City.Equals(upi.City) &&
                    Country.Equals(upi.Country) &&
                    PhoneNumber.Equals(upi.PhoneNumber);
            }
            return false;
        }
    }
}
