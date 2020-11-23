using Acupunctuur.Business;
using Acupunctuur.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Acupunctuur.Controllers {
    public class UserController : Controller {
        private readonly BuPage PModel;
        private readonly BuUser UModel;
        private readonly BuReservations RModel;
        private readonly SessionManager sessMan;
        private readonly TimeManager timeManager;
        private readonly EmailManager emailManager;

        public UserController(BuPage buPage, BuUser buUser, BuReservations buReservations, SessionManager sessMan, EmailManager emailManager, TimeManager timeManager) {
            PModel = buPage;
            UModel = buUser;
            RModel = buReservations;
            this.emailManager = emailManager;
            this.sessMan = sessMan;
            this.timeManager = timeManager;
        }

        /**
         * GET /User/Login
         */
        public IActionResult Login() {
            ValidViewModel pageVM = new ValidViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "Login",
                    DisplayName = "Inloggen"
                },
                Dynamic = false,
                Error = 0
            };
            return View(pageVM);
        }

        /**
         * POST /User/Login?email=X&password=X
         */
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password) {
            User user = UModel.ValidateLogin(email, password);
            if (user != null) {
                sessMan.Login(user.Id, user.FirstName, user.Admin);
                return RedirectToAction("Main", "Page");
            } else {
                ValidViewModel pageVM = new ValidViewModel {
                    Pages = PModel.GetMenu(),
                    CurrentPage = new Page {
                        InternalName = "Login",
                        DisplayName = "Inloggen"
                    },
                    Dynamic = false,
                    Error = 1
                };
                return View(pageVM);
            }
        }

        /**
         * GET /User/Registration
         */
        public IActionResult Registration() {
            RegistrationViewModel pageVM = new RegistrationViewModel {
                Pages = PModel.GetMenu(),
                Error = 0,
                CurrentPage = new Page {
                    InternalName = "Registration",
                    DisplayName = "Registreren"
                },
                Dynamic = false,
                SelectedDay = timeManager.Today()
            };
            return View(pageVM);
        }

        /**
         * POST /User/Registration?email=X&firstName=X&lastName=X&password=X&newUser=X&address=X&houseNumber=X&postalCode=X&country=X&telephoneNumber=X&city=X
         */
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Registration(string email, string firstName, string lastName, string password, DateTime dateOfBirth, bool newUser,
            string address, string houseNumber, string postalCode, string country, string telephoneNumber, string city) {
            if (UModel.ValidateRegistration(email)) {
                User user = UModel.MakeUser(email, firstName, password, newUser);
                user.UserPrivacyInfo = UModel.MakePrivacyInfo(lastName, dateOfBirth, address, houseNumber, postalCode, country, UModel.FormatPhoneNumber(telephoneNumber), city);
                UModel.AddUser(user);
                emailManager.SendNewAccountEmail(user);
                return RedirectToAction("Login", "User");
            } else {
                RegistrationViewModel pageVM = new RegistrationViewModel {
                    Pages = PModel.GetMenu(),
                    CurrentPage = new Page {
                        InternalName = "Registration",
                        DisplayName = "Registreren"
                    },
                    Dynamic = false,
                    Error = 1
                };
                return View(pageVM);
            }
        }

        /**
         * GET /User/ChangePassword
         */
        public IActionResult ChangePassword() {
            if (!sessMan.IsLoggedIn()) {
                return RedirectToAction("Main", "Page");
            }

            ValidViewModel pageVM = new ValidViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "ChangePassword",
                    DisplayName = "Wachtwoord Wijzigen"
                },
                Dynamic = false,
                Error = 0
            };
            return View(pageVM);
        }

        /**
         * POST /User/ChangePassword?oldPassword=X&password=X
         */
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ChangePassword(string oldPassword, string password) {
            if (!sessMan.IsLoggedIn()) {
                return RedirectToAction("Main", "Page");
            }

            User user = UModel.GetUserById(sessMan.GetUserId());
            user = UModel.ValidateUser(user, oldPassword);
            if (user != null) {
                UModel.ChangePassword(user, password);
                return RedirectToAction("Main", "Page");
            } else {
                ValidViewModel pageVM = new ValidViewModel {
                    Pages = PModel.GetMenu(),
                    CurrentPage = new Page {
                        InternalName = "ChangePassword",
                        DisplayName = "Wachtwoord Wijzigen"
                    },
                    Dynamic = false,
                    Error = 1
                };
                return View(pageVM);
            }
        }

        /**
         * GET /User/Logout
         */
        public IActionResult Logout() {
            sessMan.Logout();
            return RedirectToAction("Main", "Page");
        }

        /**
         * GET /User/ClientSearch
         */
        public IActionResult ClientSearch() {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            var pageVM = new PageViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "ClientSearch",
                    DisplayName = "Klant zoeken"
                },
                Dynamic = false
            };
            return View(pageVM);
        }

        /**
         * POST /User/ClientSearch?query=X
         */
        [HttpPost]
        public IList<ClientSearchResult> ClientSearch(string query) {
            if (!sessMan.IsAdmin()) {
                return new List<ClientSearchResult>();
            }
            return UModel.GetUsersByCriteria(query);
        }

        /**
         * GET /User/File?id=X
         */
        public IActionResult File(int id) {
            // Delete this if whenever we want to implement clients viewing their own file
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            var pageVM = new ClientFileViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "ClientFile",
                    DisplayName = "Klantdossier"
                },
                Dynamic = false,
                User = UModel.GetUserByIdWithPrivacyInfo(id),
                Reservations = RModel.GetReservationExtendeds(id)
            };
            return View(pageVM);
        }
    }
}
