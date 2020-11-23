using Acupunctuur.data;
using Acupunctuur.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acupunctuur.Business {
    public class BuUser
    {
        public IRepository<User> Users { get; set; }
        private Hasher Hasher { get; set; }

        public BuUser(IRepository<User> users)
        {
            Users = users;
            Hasher = new Hasher();
        }

        public User ValidateLogin(string email, string password)
        {
            List<User> users = Users.GetAll();
            User user = users.Where(u => u.Email == email).FirstOrDefault();
            return ValidateUser(user, password);
        }

        public User ValidateUser(User user, string password)
        {
            if (user != null)
            {
                if (!Hasher.CompareHash(password, user.Password))
                {
                    user = null;
                }
            }
            return user;
        }

        public bool ValidateRegistration(string email)
        {
            User user = Users.GetAll().Where(u => u.Email == email).FirstOrDefault();
            return user == null;
        }

        public string FormatPhoneNumber(string phone) {
            int firstNumberIndex = phone.IndexOf('-') + 1;
            if(phone[firstNumberIndex] == '0') {
                return phone.Substring(0, firstNumberIndex) + phone.Substring(firstNumberIndex + 1, phone.Length - firstNumberIndex - 1);
            }
            return phone;
        }

        public User MakeUser(string email, string firstName, string password, bool newUser)
        {
            byte[] binaryPassword = Hasher.Hash(password);
            User user = new User
            {
                Email = email,
                FirstName = firstName,
                Password = binaryPassword,
                NewUser = newUser,
                Admin = false
            };
            return user;
        }


        public UserPrivacyInfo MakePrivacyInfo(string lastName, DateTime dateOfBirth, string houseAdress, string houseNumber, string postcode, string country, string phoneNumber, string city)
        {
            UserPrivacyInfo privacyInfo = new UserPrivacyInfo
            {
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                HouseAddress = houseAdress,
                HouseNumber = houseNumber,
                PostCode = postcode,
                City = city,
                Country = country,
                PhoneNumber = phoneNumber
            };
            return privacyInfo;
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            Users.SaveChanges();
        }
        public User GetUserById(int id)
        {
            return Users.Query().Where(u => u.Id == id).Include(u => u.Reservations).ThenInclude(r => r.Timeslot)
                .Include(u => u.Reservations).ThenInclude(r => r.Cancellation).FirstOrDefault();
        }

        public User GetUserByIdWithPrivacyInfo(int id) {
            return Users.Query().Where(u => u.Id == id).Include(u => u.UserPrivacyInfo).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            Users.Update(user);
            Users.SaveChanges();
        }

        public void ChangePassword(User user, string password)
        {
            user.Password = Hasher.Hash(password);
            Users.Update(user);
            Users.SaveChanges();
        }

        public IList<ClientSearchResult> GetUsersByCriteria(string criteria)
        {
            IList<User> users = new List<User>() { };
            string[] words = criteria.Split(' ');
            foreach (string word in words)
            {
                if(word != "")
                {
                    IList<User> foundUsers = FindUsersByCriteria(word);
                    users = users.Concat(foundUsers).ToList();
                }               
            }
            users = users.Distinct().ToList();
            return GetClientSearchResultByUser(users);
        }

        private IList<User> FindUsersByCriteria(string critera) // put in John Wick krijg je elke John en elke Wick
        {
            return Users.Query().Include(u => u.UserPrivacyInfo).Where(u =>
                         u.Email.Contains(critera) ||
                         u.FirstName.Contains(critera) ||
                         u.UserPrivacyInfo.LastName.Contains(critera) ||
                         u.UserPrivacyInfo.PhoneNumber.Contains(critera)).
                         Where(u => u.Admin == false).ToList();
        }

        public IList<User> GetAllAdmins() {
            return Users.Query().Where(u => u.Admin).Include(u => u.UserPrivacyInfo).ToList();
        }

        private IList<ClientSearchResult> GetClientSearchResultByUser(IList<User> users)
        {
            IList <ClientSearchResult> CSR = new List<ClientSearchResult>();
            foreach(User user in users)
            {
                CSR.Add(new ClientSearchResult
                {
                    Id = user.Id,
                    FullName = user.FirstName + " " + user.UserPrivacyInfo.LastName,
                    Email = user.Email,
                    PhoneNumber = user.UserPrivacyInfo.PhoneNumber
                });                  
            }
            return CSR;
        }
    }
}
