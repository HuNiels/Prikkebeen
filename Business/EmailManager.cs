using Acupunctuur.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace Acupunctuur.Business {
    public class EmailManager {
        private readonly string PRIKKEBEEN_EMAIL = "noreply.prikkebeen@gmail.com";
        private readonly string PRIKKEBEEN_NAME = "Prikkebeen Acupunctuur";
        private readonly string SMTP_SERVER = "smtp.gmail.com";
        private readonly int SMTP_PORT = 587;
        private readonly string PRIKKEBEEN_PASSWORD = "prikkebeen123!";

        private readonly string EMAIL_NEWACCOUNT = "Email_NewAccount";
        private readonly string EMAIL_RESERVATION_CONFIRMATION = "Email_ReservationConfirmation";
        private readonly string EMAIL_RESERVATION_CANCELLATION_ADMIN_48 = "Email_ReservationCancellation_Admin_48";
        private readonly string EMAIL_RESERVATION_CANCELLATION_ADMIN_1 = "Email_ReservationCancellation_Admin_1";
        private readonly string EMAIL_RESERVATION_CANCELLATION_CLIENT = "Email_ReservationCancellation_Client";
        private readonly string EMAIL_RESERVATION_CANCELLATION_CLIENT_48 = "Email_ReservationCancellation_Client_48";
        private readonly string EMAIL_RESERVATION_CANCELLATION_CLIENT_1 = "Email_ReservationCancellation_Client_1";
        private readonly string EMAIL_RESERVATION_CREATION_BY_ADMIN = "Email_ReservationCreation_ByAdmin";
        private readonly string EMAIL_RESERVATION_CANCELLATION_BY_ADMIN = "Email_ReservationCancellation_ByAdmin";
        private readonly string EMAIL_REMINDER = "Email_Reminder";

        private readonly string SUBJ_NEWACCOUNT = "Prikkebeen Registratiebevestiging";
        private readonly string SUBJ_RESERVATION_CONFIRMATION = "Prikkebeen Reserveringsbevestiging";
        private readonly string SUBJ_RESERVATION_CANCELLATION_ADMIN_48 = "Prikkebeen Reservering Geannuleerd: Binnen 48 uur";
        private readonly string SUBJ_RESERVATION_CANCELLATION_ADMIN_1 = "Prikkebeen Reservering Geannuleerd: Binnen 1 uur";
        private readonly string SUBJ_RESERVATION_CANCELLATION_CLIENT = "Prikkebeen Reservering Geannuleerd";
        private readonly string SUBJ_RESERVATION_CANCELLATION_CLIENT_48 = "Prikkebeen Reservering Geannuleerd: Binnen 48 uur";
        private readonly string SUBJ_RESERVATION_CANCELLATION_CLIENT_1 = "Prikkebeen Reservering Geannuleerd: Binnen 1 uur";
        private readonly string SUBJ_RESERVATION_CREATION_BY_ADMIN = "Prikkebeen Reserveringsbevestiging: Gemaakt Door Acupuncturist";
        private readonly string SUBJ_RESERVATION_CANCELLATION_BY_ADMIN = "Prikkebeen Reservering Geannuleerd: Door Acupuncturist";
        private readonly string SUBJ_REMINDER = "Prikkebeen Herinnering Reservering";

        private readonly string TAG_ADMIN_FIRST_NAME = "@{ADMIN_FIRST_NAME}";
        private readonly string TAG_FIRST_NAME = "@{FIRST_NAME}";
        private readonly string TAG_LAST_NAME = "@{LAST_NAME}";
        private readonly string TAG_DATE_OF_BIRTH = "@{DATE_OF_BIRTH}";
        private readonly string TAG_HOUSE_ADDRESS = "@{HOUSE_ADDRESS}";
        private readonly string TAG_HOUSE_NUMBER = "@{HOUSE_NUMBER}";
        private readonly string TAG_POSTAL_CODE = "@{POSTAL_CODE}";
        private readonly string TAG_CITY = "@{CITY}";
        private readonly string TAG_COUNTRY = "@{COUNTRY}";
        private readonly string TAG_TELEPHONE_NUMBER = "@{TELEPHONE_NUMBER}";
        private readonly string TAG_RES_DATE = "@{RES_DATE}";
        private readonly string TAG_RES_START_TIME = "@{RES_START_TIME}";
        private readonly string TAG_RES_END_TIME = "@{RES_END_TIME}";

        private readonly string DOB_FORMAT = "dd-MM-yyyy";
        private readonly string DATE_FORMAT = "dddd dd-MM-yyyy";

        private readonly string BODY_ERROR = "Er is een probleem opgetreden. Contacteer Berry Prikkebeen hier alstublieft over.";

        private readonly BuPage PModel;

        public EmailManager(BuPage pageModel) {
            PModel = pageModel;
        }

        private void SendEmail(string email, string firstName, string lastName, string subject, string body) {
            using (var message = new MailMessage()) {
                message.To.Add(new MailAddress(email, firstName + " " + lastName));
                message.From = new MailAddress(PRIKKEBEEN_EMAIL, PRIKKEBEEN_NAME);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient(SMTP_SERVER)) {
                    client.Port = SMTP_PORT;
                    client.Credentials = new NetworkCredential(PRIKKEBEEN_EMAIL, PRIKKEBEEN_PASSWORD);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }

        public void SendNewAccountEmail(User recipient) {
            Page page = PModel.GetPageByInternalName(EMAIL_NEWACCOUNT);
            string body = BODY_ERROR;
            if(page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, recipient);
            }
            SendEmail(recipient.Email, recipient.FirstName, recipient.UserPrivacyInfo.LastName, SUBJ_NEWACCOUNT, body);
        }

        public void SendReservationConfirmationEmail(User recipient, Reservation res) {
            Page page = PModel.GetPageByInternalName(EMAIL_RESERVATION_CONFIRMATION);
            string body = BODY_ERROR;
            if (page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, recipient);
                body = SubstituteReservationTags(body, res);
            }
            SendEmail(recipient.Email, recipient.FirstName, recipient.UserPrivacyInfo.LastName, SUBJ_RESERVATION_CONFIRMATION, body);
        }

        public void SendReservationCancellationAdmin48Email(User admin, User user, Reservation res) {
            Page page = PModel.GetPageByInternalName(EMAIL_RESERVATION_CANCELLATION_ADMIN_48);
            string body = BODY_ERROR;
            if (page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, user);
                body = SubstituteReservationTags(body, res);
                body = SubstituteAdminTags(body, admin);
            }
            SendEmail(admin.Email, admin.FirstName, admin.UserPrivacyInfo.LastName, SUBJ_RESERVATION_CANCELLATION_ADMIN_48, body);
        }

        public void SendReservationCancellationAdmin1Email(User admin, User user, Reservation res) {
            Page page = PModel.GetPageByInternalName(EMAIL_RESERVATION_CANCELLATION_ADMIN_1);
            string body = BODY_ERROR;
            if (page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, user);
                body = SubstituteReservationTags(body, res);
                body = SubstituteAdminTags(body, admin);
            }
            SendEmail(admin.Email, admin.FirstName, admin.UserPrivacyInfo.LastName, SUBJ_RESERVATION_CANCELLATION_ADMIN_1, body);
        }

        public void SendReservationCancellationClientEmail(User recipient, Reservation res) {
            Page page = PModel.GetPageByInternalName(EMAIL_RESERVATION_CANCELLATION_CLIENT);
            string body = BODY_ERROR;
            if (page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, recipient);
                body = SubstituteReservationTags(body, res);
            }
            SendEmail(recipient.Email, recipient.FirstName, recipient.UserPrivacyInfo.LastName, SUBJ_RESERVATION_CANCELLATION_CLIENT, body);
        }

        public void SendReservationCancellationClient48Email(User recipient, Reservation res) {
            Page page = PModel.GetPageByInternalName(EMAIL_RESERVATION_CANCELLATION_CLIENT_48);
            string body = BODY_ERROR;
            if (page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, recipient);
                body = SubstituteReservationTags(body, res);
            }
            SendEmail(recipient.Email, recipient.FirstName, recipient.UserPrivacyInfo.LastName, SUBJ_RESERVATION_CANCELLATION_CLIENT_48, body);
        }

        public void SendReservationCancellationClient1Email(User recipient, Reservation res) {
            Page page = PModel.GetPageByInternalName(EMAIL_RESERVATION_CANCELLATION_CLIENT_1);
            string body = BODY_ERROR;
            if (page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, recipient);
                body = SubstituteReservationTags(body, res);
            }
            SendEmail(recipient.Email, recipient.FirstName, recipient.UserPrivacyInfo.LastName, SUBJ_RESERVATION_CANCELLATION_CLIENT_1, body);
        }

        public void SendReservationCreationByAdminEmail(User recipient, Reservation res) {
            Page page = PModel.GetPageByInternalName(EMAIL_RESERVATION_CREATION_BY_ADMIN);
            string body = BODY_ERROR;
            if (page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, recipient);
                body = SubstituteReservationTags(body, res);
            }
            SendEmail(recipient.Email, recipient.FirstName, recipient.UserPrivacyInfo.LastName, SUBJ_RESERVATION_CREATION_BY_ADMIN, body);
        }

        public void SendReservationCancellationByAdminEmail(User recipient, Reservation res) {
            Page page = PModel.GetPageByInternalName(EMAIL_RESERVATION_CANCELLATION_BY_ADMIN);
            string body = BODY_ERROR;
            if (page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, recipient);
                body = SubstituteReservationTags(body, res);
            }
            SendEmail(recipient.Email, recipient.FirstName, recipient.UserPrivacyInfo.LastName, SUBJ_RESERVATION_CANCELLATION_BY_ADMIN, body);
        }

        public void SendReservationReminderEmail(User recipient, Reservation res) {
            Page page = PModel.GetPageByInternalName(EMAIL_REMINDER);
            string body = BODY_ERROR;
            if (page != null) {
                body = page.Content.RawHtml;
                body = SubstituteUserTags(body, recipient);
                body = SubstituteReservationTags(body, res);
            }
            SendEmail(recipient.Email, recipient.FirstName, recipient.UserPrivacyInfo.LastName, SUBJ_REMINDER, body);
        }

        private string SubstituteAdminTags(string text, User admin) {
            return text.Replace(TAG_ADMIN_FIRST_NAME, admin.FirstName);
        }

        private string SubstituteUserTags(string text, User user) {
            UserPrivacyInfo upi = user.UserPrivacyInfo;
            return text.Replace(TAG_FIRST_NAME, user.FirstName).Replace(TAG_LAST_NAME, upi.LastName)
                .Replace(TAG_DATE_OF_BIRTH, upi.DateOfBirth.ToString(DOB_FORMAT)).Replace(TAG_HOUSE_ADDRESS, upi.HouseAddress)
                .Replace(TAG_HOUSE_NUMBER, upi.HouseNumber).Replace(TAG_POSTAL_CODE, upi.PostCode)
                .Replace(TAG_CITY, upi.City).Replace(TAG_COUNTRY, upi.Country).Replace(TAG_TELEPHONE_NUMBER, upi.PhoneNumber);
        }
        
        private string SubstituteReservationTags(string text, Reservation res) {
            return text.Replace(TAG_RES_DATE, res.Date.ToString(DATE_FORMAT, new System.Globalization.CultureInfo("nl-NL")))
                .Replace(TAG_RES_START_TIME, ConvertToTimeFormat(res.Timeslot.StartTime))
                .Replace(TAG_RES_END_TIME, ConvertToTimeFormat(res.Timeslot.EndTime));
        }

        private string ConvertToTimeFormat(TimeSpan time) {
            return $"{time.Hours.ToString().PadLeft(2, '0')}:{time.Minutes.ToString().PadLeft(2, '0')}";
        }
    }
}
