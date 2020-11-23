using Acupunctuur.data;
using Acupunctuur.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acupunctuur.Business {
    public class BuReservations {
        public IRepository<Reservation> Reservations { get; set; }
        public IRepository<Timeslot> Timeslots { get; set; }
        public IRepository<TimeslotLink> TimeslotLinks { get; set; }
        public IRepository<Cancellation> Cancellations { get; set; }
        public IRepository<BlockedPeriod> BlockedPeriods { get; set; }
        private readonly SessionManager sessMan;
        private readonly TimeManager timeManager;
        private BuUser Umodel { get; set; }

        public BuReservations(IRepository<Reservation> reservations, IRepository<Timeslot> timeslots, IRepository<TimeslotLink> timeslotLinks, IRepository<BlockedPeriod> blockedPeriods, IRepository<Cancellation> cancellations, SessionManager sessMan, BuUser uModel, TimeManager timeManager) {
            Reservations = reservations;
            Timeslots = timeslots;
            TimeslotLinks = timeslotLinks;
            BlockedPeriods = blockedPeriods;
            Cancellations = cancellations;
            this.timeManager = timeManager;
            this.sessMan = sessMan;
            Umodel = uModel;
        }

        public Timeslot FindTimeslotById (int Id)
        {
            return Timeslots.GetAll().Where(t => t.Id == Id).FirstOrDefault();
        }

        public Reservation MakeReservation(Timeslot timeslot, DateTime date) {
            return MakeReservation(sessMan.GetUserId(), timeslot, date);
        }

        public Reservation MakeReservation(int userId, Timeslot timeslot, DateTime date) {
            if (userId < 0) return null;
            User currentUser = Umodel.GetUserByIdWithPrivacyInfo(userId);
            Reservation reservation = new Reservation() {
                Timeslot = timeslot,
                User = currentUser,
                Date = date,
                Cancellation = null
            };
            return reservation;
        }

        public void AddReservation(Reservation reservation) {
            Reservations.Add(reservation);
            Reservations.SaveChanges();
        }

        public void CancelReservation(Reservation reservation) {
            int userId = sessMan.GetUserId();
            User user = Umodel.GetUserById(userId);
            bool admin = user.Admin;
            CancelStatus cancelStatus;
            if (admin) { cancelStatus = CancelStatus.InTime; }
            else
            {
                int timeTillReservation = HowLongUntil(reservation);
                cancelStatus = CancelStatusFromHours(timeTillReservation);
            }
            Cancellation cancellation = new Cancellation()
            {
                Reservation = reservation,
                ByAdmin = admin,
                CancelStatus = cancelStatus,
                Done = admin,
                CancelDate = timeManager.Now()
            };

            Cancellations.Add(cancellation);
            Reservations.SaveChanges();
        }

        public IList<LateCancellationInfo> GetUnhandledLateCancellations() {
            var list = Cancellations.Query().Where(c => !c.Done && c.CancelStatus != CancelStatus.InTime && !c.ByAdmin)
                .OrderByDescending(c => c.Reservation.Date).ThenBy(c => c.Reservation.Timeslot.StartTime)
                .Include(c => c.Reservation).ThenInclude(r => r.Timeslot)
                .Include(c => c.Reservation).ThenInclude(r => r.User).ThenInclude(u => u.UserPrivacyInfo).ToList();
            return ConvertCancellationToInfo(list);
        }

        private IList<LateCancellationInfo> ConvertCancellationToInfo(IList<Cancellation> input) {
            IList<LateCancellationInfo> result = new List<LateCancellationInfo>();
            foreach(Cancellation c in input) {
                var subresult = new LateCancellationInfo {
                    CancellationId = c.Id,
                    UserId = c.Reservation.User.Id,
                    FullName = c.Reservation.User.FirstName + " " + c.Reservation.User.UserPrivacyInfo.LastName,
                    Date = c.Reservation.Date,
                    Status = c.CancelStatus,
                    Timeslot = c.Reservation.Timeslot
                };
                result.Add(subresult);
            }
            return result;
        }

        public void UpdateLateCancellations(int[] ids) {
            foreach(int id in ids) {
                var cancellation = Cancellations.GetAll().Where(c => c.Id == id).FirstOrDefault();
                cancellation.Done = true;
                Cancellations.Update(cancellation);
            }
            Cancellations.SaveChanges();
        }

        public int HowLongUntil(Reservation reservation)
        {
            DateTime now = timeManager.Now();
            TimeSpan timeDiff = reservation.Timeslot.StartTime - now.TimeOfDay;
            TimeSpan dayDiff = reservation.Date.Date - now.Date;
            TimeSpan totalDiff = timeDiff + dayDiff;
            return totalDiff.Days * 24 + totalDiff.Hours;
        }

        public CancelStatus CancelStatusFromHours(int hours)
        {
            if (hours == 0) return CancelStatus.OneHour;
            else if (hours < 48) return CancelStatus.FourtyEightHours;
            else return CancelStatus.InTime;
        }

        public Reservation FindReservationById(int id) {
            return Reservations.Query().Where(r => r.Id == id).Include(r => r.Timeslot).FirstOrDefault();
        }

        public Reservation FindReservationByIdWithUser(int id) {
            return Reservations.Query().Where(r => r.Id == id).Include(r => r.Timeslot)
                .Include(r => r.User).ThenInclude(u => u.UserPrivacyInfo).FirstOrDefault();
        }

        public Reservation FindCurrentReservation() {
            int userId = sessMan.GetUserId();
            if (userId == -1) return null;
            User currentUser = Umodel.GetUserById(userId);
            return currentUser.Reservations.Where(r => r.Cancellation == null)
                .Where(r => r.Date >= timeManager.Today()).FirstOrDefault();
        }

        public bool IsFirstTime(int? userId) {
            int id;
            if (userId == null) id = sessMan.GetUserId();
            else id = Convert.ToInt32(userId);
            if (id == -1) return false;
            User currentUser = Umodel.GetUserById(id);
            return currentUser.NewUser;
        }

        public bool HasReservation() {
            int userId = sessMan.GetUserId();
            if (userId == -1) return false;
            User currentUser = Umodel.GetUserById(userId);
            var today = timeManager.Today();
            return currentUser.Reservations.Where(r => r.Cancellation == null)
                .Where(r => (r.Date > today) ||
                (r.Date == today && timeManager.Now().TimeOfDay <= r.Timeslot.EndTime)).Any();
        }

        public void SetUserToExisting() {
            SetUserToExisting(sessMan.GetUserId());
        }

        public void SetUserToExisting(int userId) {
            if (userId > 0) {
                User currentUser = Umodel.GetUserById(userId);
                if (currentUser.NewUser == true) {
                    currentUser.NewUser = false;
                    Umodel.UpdateUser(currentUser);
                }
            }
        }

        public IList<ReservationExtended> GetReservationExtendeds()
        {
            return GetReservationExtendeds(sessMan.GetUserId());
        }

        public IList<ReservationExtended> GetReservationExtendeds(int userId) {
            User user = Umodel.GetUserById(userId);
            IList<ReservationExtended> ResEx = new List<ReservationExtended>();
            List<Reservation> reservations = GetReservationsByUser(user);

            foreach (Reservation reservation in reservations) {
                ResEx.Add(ConvertToReservationEx(reservation));
            }
            return ResEx.OrderByDescending(r => r.Date).ThenByDescending(r => r.Timeslot.StartTime).ToList();
        }

        public IList<TimeslotJsonExtended> GetAdminOverview(DateTime date)
        {
            IList<TimeslotJsonExtended> TSJE = new List<TimeslotJsonExtended>();

            if (IsWeekend(date)) return TSJE;

            IList<Reservation> reservations = GetReservationsByDate(date);
            List<Reservation> dReservations = reservations.Where(r => r.Timeslot.DoubleSlot == true).ToList(); // all doubleslot reservations
            List<Reservation> sReservations = reservations.Where(r => r.Timeslot.DoubleSlot == false).ToList(); // all singleslot reservations

            List<Timeslot> sTimeslots = GetAllTimeslotsByDouble(false); //all single timeslots

            List<Timeslot> blockedSTimeslots = GetBlockedTimeslotsByReservations(dReservations); 
            sReservations.ForEach(r => blockedSTimeslots.Add(r.Timeslot)); // all blocked single timeslots
            List<Timeslot> timeslots = sTimeslots.Except(blockedSTimeslots).ToList(); // all free single timeslots

            foreach (Timeslot timeslot in timeslots) // add all free single timeslots to the list
            {
                TSJE.Add(new TimeslotJsonExtended
                {
                    Id = timeslot.Id,
                    StartTime = timeslot.StartTime,
                    EndTime = timeslot.EndTime,
                    UserName = null,
                    DoubleSlot = false
                });
            }
            foreach (Reservation reservation in reservations) // add all reserved timeslots to the list
            {
                TSJE.Add(new TimeslotJsonExtended
                {
                    Id = reservation.Timeslot.Id,
                    StartTime = reservation.Timeslot.StartTime,
                    EndTime = reservation.Timeslot.EndTime,
                    UserId = reservation.User.Id,
                    UserName = $"{reservation.User.FirstName} {reservation.User.UserPrivacyInfo.LastName}",
                    DoubleSlot = reservation.Timeslot.DoubleSlot
                });
            }
            return TSJE.OrderBy(t => t.StartTime).ToList();
        }

        public IList<TimeslotJson> GetTimeslots(DateTime date, bool dSlots) {
            IList<TimeslotJson> TSJ = new List<TimeslotJson>();
            if (IsWeekend(date)) return TSJ;
            int userId = sessMan.GetUserId();  

            List<Timeslot> timeslots = GetAllTimeslotsByDouble(dSlots);
            IList<Reservation> reservations = GetReservationsByDate(date);
            Reservation resbycurrentUser = reservations.Where(r => r.User.Id == userId).FirstOrDefault(); // made by current user
            List<Timeslot> blockedTimeslots = GetBlockedTimeslotsByReservations(reservations.Where(r => r.User.Id != userId).ToList()); //not made by current user

           
            List<Timeslot> timeslotscurrentUser = GetBlockedTimeslotsByReservation(resbycurrentUser);

            foreach (Timeslot timeslot in timeslots) {
                bool currentUser = timeslotscurrentUser.Where(u => u.Id == timeslot.Id).Any();
                TSJ.Add(new TimeslotJson
                {
                    Id = timeslot.Id,
                    StartTime = timeslot.StartTime,
                    EndTime = timeslot.EndTime,
                    Available = IsInTheFuture(date, timeslot) && !blockedTimeslots.Where(b => b.Id == timeslot.Id).Any()
                             && !currentUser && !IsInBlockedPeriod(date, timeslot),
                    CurrentUser = currentUser
                });
            }
            return TSJ;
        }

        private bool IsInTheFuture(DateTime date, Timeslot timeslot) {
            var today = timeManager.Today();
            return date > today || (date == today && timeManager.Now().TimeOfDay < timeslot.StartTime);
        }

        private bool IsInBlockedPeriod(DateTime date, Timeslot timeslot) {
            DateTime timeslotStart = date + timeslot.StartTime;
            DateTime timeslotEnd = date + timeslot.EndTime;

            // Check if the start or end of the timeslot is inside any blocked period
            return BlockedPeriods.Query().Where(bp => 
                (timeslotStart >= bp.StartDatetime && timeslotStart <= bp.EndDatetime) ||
                (timeslotEnd >= bp.StartDatetime && timeslotEnd <= bp.EndDatetime)
            ).Any();

            // Different flavor, same functionality. Choose one.
            return BlockedPeriods.Query().Where(bp => (date > bp.StartDatetime && date < bp.EndDatetime) ||
                (date == bp.StartDatetime.Date && bp.StartDatetime.TimeOfDay >= timeslot.StartTime) ||
                (date == bp.EndDatetime.Date && bp.EndDatetime.TimeOfDay <= timeslot.EndTime))
                .Any();
        }

        public bool DoesPeriodContainReservations(DateTime start, DateTime end) {
            return Reservations.Query().Where(r => (r.Date > start.Date && r.Date < end.Date) ||
                (r.Date == start.Date && r.Timeslot.EndTime >= start.TimeOfDay) ||
                (r.Date == end.Date && r.Timeslot.StartTime <= end.TimeOfDay))
                .Any();
        }

        private ReservationExtended ConvertToReservationEx(Reservation reservation)
        {
            ReservationExtended resEx = new ReservationExtended
            {
                Id = reservation.Id,
                Date = reservation.Date,
                Cancellation = reservation.Cancellation,
                User = reservation.User,
                Timeslot = reservation.Timeslot,
                Status = GetReservationStatus(reservation)
            };
            return resEx;
        }

        public BlockedPeriod FindBlockedPeriodByDate(DateTime date)
        {
            TimeSpan now = timeManager.Now().TimeOfDay;
            return BlockedPeriods.GetAll().Where(b => b.EndDatetime.Date > date && b.StartDatetime.Date <= date ||
                                          b.EndDatetime.Date == date && b.EndDatetime.TimeOfDay > now)                                
                                         .OrderByDescending(b => b.StartDatetime).FirstOrDefault();
        }

        public IList<BlockedPeriod> GetAllBlockedPeriodsFuture()
        {
            DateTime now = timeManager.Now();
            return BlockedPeriods.GetAll().Where(b => b.EndDatetime > now).OrderByDescending(b => b.StartDatetime).ToList();
        }

        public void DeleteBlockedPeriod(BlockedPeriod blockedPeriod)
        {
            BlockedPeriods.Delete(blockedPeriod);
            BlockedPeriods.SaveChanges();
        }

        public BlockedPeriod GetBlockedPeriodById(int blockId)
        {
            return BlockedPeriods.GetAll().Where(b => b.Id == blockId).FirstOrDefault();
        }

        public BlockedPeriod MakeBlockedPeriod(DateTime start, DateTime end, string description, string customerMessage)
        {
            return new BlockedPeriod
            {
                StartDatetime = start,
                EndDatetime = end,
                Description = description,
                CustomerMessage = customerMessage
            };
        }

        public void AddBlockedPeriod (BlockedPeriod blockedPeriod)
        {
            BlockedPeriods.Add(blockedPeriod);
            BlockedPeriods.SaveChanges();
        }

        private bool IsWeekend(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
        }

        public bool IsChronological(DateTime a, DateTime b) {
            return b >= a;
        }

        private ReservationStatus GetReservationStatus(Reservation reservation)
        {
            var today = timeManager.Today();
            if (reservation.Cancellation != null) return ReservationStatus.Cancelled;
            else if (reservation.Date > today || (reservation.Date == today && timeManager.Now().TimeOfDay < reservation.Timeslot.StartTime)) return ReservationStatus.Active;
            else return ReservationStatus.Done;           
        }

        private List<Timeslot> GetAllTimeslotsByDouble(bool dslot) {
            return Timeslots.GetAll().Where(t => t.DoubleSlot == dslot).ToList();
        }

        public IList<Reservation> GetReservationsByDate(DateTime date) {
            date = date.Date;
            return Reservations.Query().Where(d => d.Date == date).Where(r => r.Cancellation == null)
                               .Include(r =>r.User).ThenInclude(u => u.UserPrivacyInfo).Include(r => r.Timeslot).ThenInclude(ts => ts.TimeslotBases).ThenInclude(tsb => tsb.Link).ToList();
        }

        private List<Reservation> GetReservationsByUser(User user)
        {
            return Reservations.Query().Where(r => r.User.Id == user.Id)
                               .Include(r => r.Timeslot).Include(r => r.Cancellation).ToList();
        }

        public Cancellation GetCancellationByReservationId(int resId) {
            return Cancellations.GetAll().Where(c => c.ReservationId == resId).FirstOrDefault();
        }

        private List<Timeslot> GetBlockedTimeslotsByReservations(List<Reservation> reservations) {
            List<Timeslot> blockedTimeslots = new List<Timeslot>();

            foreach (Reservation reservation in reservations) {
                blockedTimeslots = blockedTimeslots.Union(GetBlockedTimeslotsByReservation(reservation)).ToList();
            }
            return blockedTimeslots;
        }

        private List<Timeslot> GetBlockedTimeslotsByReservation(Reservation reservation)
        {
            List<Timeslot> blockedTimeslots = new List<Timeslot>();
            if(reservation == null) {
                return blockedTimeslots;
            }

            blockedTimeslots.Add(reservation.Timeslot);

            foreach (TimeslotLink link in reservation.Timeslot.TimeslotBases)
            {
                blockedTimeslots.Add(link.Link);
            }
            return blockedTimeslots;
        }
    }
}