using Acupunctuur.Business;
using Microsoft.AspNetCore.Mvc;

namespace Acupunctuur.Controllers {
    public class EmailController : Controller {
        private readonly SessionManager sessMan;
        private readonly BuEmails EModel;

        public EmailController(BuEmails emailModel, SessionManager sessMan) {
            EModel = emailModel;
            this.sessMan = sessMan;
        }

        [HttpPost]
        public IActionResult NotifyAll() {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }
            EModel.SendReminderEmailsToNextDayReservations();
            return RedirectToAction("AdminOverview", "Reservation");
        }
    }
}
