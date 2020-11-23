using Acupunctuur.Models;
using System;
using System.Collections.Generic;

namespace Acupunctuur.Business {
    public class BuEmails {
        private readonly BuReservations RModel;
        private readonly BuUser UModel;
        private readonly TimeManager timeManager;
        private readonly EmailManager emailManager;

        public BuEmails(BuReservations resModel, BuUser userModel, TimeManager tm, EmailManager em) {
            RModel = resModel;
            UModel = userModel;
            timeManager = tm;
            emailManager = em;
        }

        public void SendReminderEmailsToNextDayReservations() {
            DateTime nextDay = timeManager.NextDay(timeManager.Today());
            IList<Reservation> resList = RModel.GetReservationsByDate(nextDay);
            foreach(var res in resList) {
                emailManager.SendReservationReminderEmail(res.User, res);
            }
        }

        public void SendCancellationEmails(Reservation res, User user, Cancellation cxl) {
            IList<User> admins = UModel.GetAllAdmins();
            if(cxl.ByAdmin) {
                emailManager.SendReservationCancellationByAdminEmail(user, res);
            } else {
                switch (cxl.CancelStatus) {
                    case CancelStatus.FourtyEightHours:
                        emailManager.SendReservationCancellationClient48Email(user, res);
                        foreach (var admin in admins) {
                            emailManager.SendReservationCancellationAdmin48Email(admin, user, res);
                        }
                        break;
                    case CancelStatus.OneHour:
                        emailManager.SendReservationCancellationClient1Email(user, res);
                        foreach (var admin in admins) {
                            emailManager.SendReservationCancellationAdmin1Email(admin, user, res);
                        }
                        break;
                    case CancelStatus.InTime:
                        emailManager.SendReservationCancellationClientEmail(user, res);
                        break;
                }
            }
        }
    }
}
