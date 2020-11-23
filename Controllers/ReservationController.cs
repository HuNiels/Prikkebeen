using Acupunctuur.Business;
using Acupunctuur.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Acupunctuur.Controllers {
    public class ReservationController : Controller {
        private static readonly string confirmationData = "ConfirmationData";
        private readonly BuPage PModel;
        private readonly BuReservations RModel;
        private readonly BuUser UModel;
        private readonly BuEmails EModel;
        private readonly TimeManager timeManager;
        private readonly SessionManager sessMan;
        private readonly EmailManager emailMan;

        public ReservationController(BuPage buPage, BuReservations buReservations, BuUser buUser, BuEmails buEmails, TimeManager timeManager, SessionManager sessMan, EmailManager emailMan) {
            PModel = buPage;
            RModel = buReservations;
            UModel = buUser;
            EModel = buEmails;
            this.timeManager = timeManager;
            this.sessMan = sessMan;
            this.emailMan = emailMan;
        }

        /**
         * GET /Reservation/Schedule
         */
        public IActionResult Schedule() {
            ReservationViewModel pageVM = new ReservationViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "Schedule",
                    DisplayName = "Reserveren"
                },
                Dynamic = false,
                NewUser = RModel.IsFirstTime(null),
                HasAReservation = RModel.HasReservation(),
                SelectedDay = timeManager.Today(),
                LastDay = timeManager.LastDay(),
                Error = 0
            };
            return View(pageVM);
        }

        /**
         * POST /Reservation/Schedule?date=X
         */
        [HttpPost]
        public ScheduleInfo Schedule(DateTime date, int? userId = null) {
            bool newUser = RModel.IsFirstTime(userId);
            IList<TimeslotJson> timeslots = RModel.GetTimeslots(date, newUser);
            string customerMessage;

            BlockedPeriod blocked = RModel.FindBlockedPeriodByDate(date);
            if (blocked == null) customerMessage = null;
            else customerMessage = blocked.CustomerMessage;

            var data = new ScheduleInfo {
                PreviousDay = timeManager.PreviousDay(date),
                NextDay = timeManager.NextDay(date),
                CustomerMessage = customerMessage,
                Timeslots = timeslots
            };
            return data;
        }

        /**
         * POST /Reservation/Reserve?selDate=X&selTimeslotId=X
         */
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Reserve(DateTime selDate, int selTimeslotId) {

            try {
                Timeslot selTimeslot = RModel.FindTimeslotById(selTimeslotId);
                Reservation newRes = RModel.MakeReservation(selTimeslot, selDate);
                RModel.AddReservation(newRes);
                RModel.SetUserToExisting();

                emailMan.SendReservationConfirmationEmail(newRes.User, newRes);

                TempData[confirmationData] = newRes.Id;
                return RedirectToAction("Confirmation", "Reservation");
            } catch {
                return RedirectToAction("Schedule", "Reservation");
            }
        }

        /**
         * GET /Reservation/Confirmation
         * Receives the data from Reserve() via TempData.
         */
        public IActionResult Confirmation() {
            int reservationId = (int)TempData[confirmationData];
            Reservation res = RModel.FindReservationById(reservationId);

            ConfirmationViewModel confirmVM = new ConfirmationViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "Confirmation",
                    DisplayName = "Reserveringsbevestiging"
                },
                Dynamic = false,
                ReservedDay = res.Date,
                TimeSlot = res.Timeslot
            };
            return View(confirmVM);
        }

        /**
         * GET /Reservation/ClientOverview
         */
        public IActionResult ClientOverview() {
            if(!sessMan.IsLoggedIn()) {
                return RedirectToAction("Main", "Page");
            }

            ClientOverviewViewModel vm = new ClientOverviewViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page
                {
                    InternalName = "ClientOverview",
                    DisplayName = "Reserveringsoverzicht"
                },
                Dynamic = false,
                Reservations = RModel.GetReservationExtendeds()
            };
            return View(vm);
        }

        /**
         * GET /Reservation/AdminOverview
         */
        public IActionResult AdminOverview() {
            if(!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            ReservationViewModel pageVM = new ReservationViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "AdminOverview",
                    DisplayName = "Agenda"
                },
                Dynamic = false,
                SelectedDay = timeManager.Today()
            };
            return View(pageVM);
        }

        /**
         * POST /Reservation/AdminOverview?date=X
         */
        [HttpPost]
        public AdminScheduleInfo AdminOverview(DateTime date) {
            if (!sessMan.IsAdmin()) {
                // Will return an data object
                return new AdminScheduleInfo();
            }
            return new AdminScheduleInfo {
                PreviousDay = timeManager.PreviousDay(date),
                NextDay = timeManager.NextDay(date),
                Timeslots = RModel.GetAdminOverview(date)
            };
        }

        /**
         * GET /Reservation/AdminSchedule?userId=X
         */
        public IActionResult AdminSchedule(int userId) {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            AdminReservationViewModel pageVM = new AdminReservationViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "AdminSchedule",
                    DisplayName = "Reserveren voor klant"
                },
                Dynamic = false,
                NewUser = RModel.IsFirstTime(userId),
                HasAReservation = RModel.HasReservation(),
                SelectedDay = timeManager.Today(),
                LastDay = timeManager.LastDay(),
                Error = 0,
                User = UModel.GetUserById(userId)
            };
            return View(pageVM);
        }

        /**
         * POST /Reservation/AdminReserve?userId=X&selDate=X&selTimeslotId=X
         */
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AdminReserve(int userId, DateTime selDate, int selTimeslotId) {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            try {
                Timeslot selTimeslot = RModel.FindTimeslotById(selTimeslotId);
                Reservation newRes = RModel.MakeReservation(userId, selTimeslot, selDate);
                RModel.AddReservation(newRes);
                RModel.SetUserToExisting(userId);

                emailMan.SendReservationCreationByAdminEmail(newRes.User, newRes);

                TempData[confirmationData] = newRes.Id;
                return RedirectToAction("AdminConfirmation", "Reservation");
            } catch {
                return RedirectToAction("ClientSearch", "User");
            }
        }

        [HttpPost]
        public CancelStatus CancelInfo(string id)
        {
            Reservation reservation = RModel.FindReservationById(Convert.ToInt32(id));
            int hours = RModel.HowLongUntil(reservation);
            if (hours < 48 && sessMan.IsAdmin()) return CancelStatus.Admin;
            return RModel.CancelStatusFromHours(hours);            
        }

        public IActionResult CancelReservation(int id)
        {
            if (sessMan.IsLoggedIn()) {
                Reservation reservation = RModel.FindReservationByIdWithUser(id);
                RModel.CancelReservation(reservation);

                Cancellation cxl = RModel.GetCancellationByReservationId(reservation.Id);
                EModel.SendCancellationEmails(reservation, reservation.User, cxl);

                if (sessMan.IsAdmin()) {
                    return RedirectToAction("File", "User", new { id = reservation.User.Id });
                } else {
                    return RedirectToAction("ClientOverview", "Reservation");
                }
            } else {
                return RedirectToAction("Main", "Page");
            }
        }

        public IActionResult CancelOverview() {
            if(sessMan.IsAdmin()) {
                CancelOverviewViewModel vm = new CancelOverviewViewModel {
                    Pages = PModel.GetMenu(),
                    CurrentPage = new Page {
                        InternalName = "CancelOverview",
                        DisplayName = "Overzicht Late Annuleringen"
                    },
                    Dynamic = false,
                    LateCancellations = RModel.GetUnhandledLateCancellations()
                };
                return View(vm);
            } else {
                return RedirectToAction("Main", "Page");
            }
        }

        [HttpPost]
        public IActionResult CancelOverview(int[] cancellationIds)
        {
            RModel.UpdateLateCancellations(cancellationIds);
            return RedirectToAction("CancelOverview", "Reservation");
        }

        /**
         * GET /Reservation/AdminConfirmation
         * Receives the data from AdminReserve() via TempData.
         */
        public IActionResult AdminConfirmation() {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            int reservationId = (int)TempData[confirmationData];
            Reservation res = RModel.FindReservationByIdWithUser(reservationId);

            AdminConfirmationViewModel confirmVM = new AdminConfirmationViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "Confirmation",
                    DisplayName = "Reserveringsbevestiging"
                },
                Dynamic = false,
                ReservedDay = res.Date,
                TimeSlot = res.Timeslot,
                UserName = $"{res.User.FirstName} {res.User.UserPrivacyInfo.LastName}"
            };
            return View(confirmVM);
        }

        public IActionResult BlockPeriod()
        {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            BlockViewModel pageVM = new BlockViewModel
            {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page
                {
                    InternalName = "BlockPeriod",
                    DisplayName = "Periode Blokkeren"
                },
                Dynamic = false,
                Today = timeManager.Today().Date,
                Error = 0
            };
            return View(pageVM);
        }

        /**
         * POST /Reservation/AdminOverview?date=X
         */
        [HttpPost]
        public IActionResult BlockPeriod(DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime, string description, string customerMessage)
        {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            DateTime start = startDate.Date + startTime;
            DateTime end = endDate.Date + endTime;

            BlockViewModel pageVM = new BlockViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "BlockPeriod",
                    DisplayName = "Periode Blokkeren"
                },
                Dynamic = false,
                Today = timeManager.Today().Date
            };

            if (!RModel.IsChronological(start, end)) {
                pageVM.Error = 2;
                return View(pageVM);
            }
            else if (RModel.DoesPeriodContainReservations(start, end))
            {
                pageVM.Error = 1;
                return View(pageVM);
            }
            else
            {
                BlockedPeriod blockedPeriod = RModel.MakeBlockedPeriod(start, end, description, customerMessage);
                RModel.AddBlockedPeriod(blockedPeriod);
                return RedirectToAction("BlockedOverview", "Reservation");
            }
        }
        public IActionResult BlockedOverview()
        {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            BlockOverviewViewModel pageVM = new BlockOverviewViewModel
            {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page
                {
                    InternalName = "BlockedOverview",
                    DisplayName = "Overzicht geblokkeerde periodes"
                },
                Dynamic = false,
                BlockedPeriods = RModel.GetAllBlockedPeriodsFuture()
            };
            return View(pageVM);
        }

        public IActionResult DeleteBlock(int id)
        {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }
            BlockedPeriod blockedPeriod = RModel.GetBlockedPeriodById(id);
            RModel.DeleteBlockedPeriod(blockedPeriod);

            return RedirectToAction("BlockedOverview", "Reservation");
        }

    }
}
