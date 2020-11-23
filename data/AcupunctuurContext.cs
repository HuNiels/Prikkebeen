using Acupunctuur.Models;
using Microsoft.EntityFrameworkCore;

namespace Acupunctuur.data {
    public class AcupunctuurContext : DbContext {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<TimeslotLink> TimeslotLinks { get; set; }
        public DbSet<UserPrivacyInfo> PrivacyInfo { get; set; }
        public DbSet<BlockedPeriod> BlockedPeriods { get; set; }
        public DbSet<Cancellation> Cancellations { get; set; }

        public AcupunctuurContext(DbContextOptions<AcupunctuurContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TimeslotLink>().HasOne(tsl => tsl.Base).WithMany(ts => ts.TimeslotBases).HasForeignKey(tsl => tsl.BaseId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TimeslotLink>().HasOne(tsl => tsl.Link).WithMany(ts => ts.TimeslotLinks).HasForeignKey(tsl => tsl.LinkId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>().HasOne(r => r.Cancellation).WithOne(c => c.Reservation).HasForeignKey<Cancellation>(c => c.ReservationId).OnDelete(DeleteBehavior.NoAction);

            Timeslot timeslot1 = new Timeslot {
                Id = 1,
                StartTime = new System.TimeSpan(8, 30, 0),
                EndTime = new System.TimeSpan(9, 15, 0),
                DoubleSlot = false,
            };
            Timeslot timeslot2 = new Timeslot {
                Id = 2,
                StartTime = new System.TimeSpan(9, 30, 0),
                EndTime = new System.TimeSpan(10, 15, 0),
                DoubleSlot = false
            };
            Timeslot timeslot3 = new Timeslot {
                Id = 3,
                StartTime = new System.TimeSpan(8, 30, 0),
                EndTime = new System.TimeSpan(10, 0, 0),
                DoubleSlot = true
            };
            Timeslot timeslot4 = new Timeslot {
                Id = 4,
                StartTime = new System.TimeSpan(10, 45, 0),
                EndTime = new System.TimeSpan(11, 30, 0),
                DoubleSlot = false,
            };
            Timeslot timeslot5 = new Timeslot {
                Id = 5,
                StartTime = new System.TimeSpan(11, 45, 0),
                EndTime = new System.TimeSpan(12, 30, 0),
                DoubleSlot = false
            };
            Timeslot timeslot6 = new Timeslot {
                Id = 6,
                StartTime = new System.TimeSpan(10, 45, 0),
                EndTime = new System.TimeSpan(12, 15, 0),
                DoubleSlot = true
            };
            Timeslot timeslot7 = new Timeslot {
                Id = 7,
                StartTime = new System.TimeSpan(13, 30, 0),
                EndTime = new System.TimeSpan(14, 15, 0),
                DoubleSlot = false,
            };
            Timeslot timeslot8 = new Timeslot {
                Id = 8,
                StartTime = new System.TimeSpan(14, 30, 0),
                EndTime = new System.TimeSpan(15, 15, 0),
                DoubleSlot = false,
            };
            Timeslot timeslot9 = new Timeslot {
                Id = 9,
                StartTime = new System.TimeSpan(15, 30, 0),
                EndTime = new System.TimeSpan(16, 15, 0),
                DoubleSlot = false
            };
            Timeslot timeslot10 = new Timeslot {
                Id = 10,
                StartTime = new System.TimeSpan(14, 30, 0),
                EndTime = new System.TimeSpan(16, 00, 0),
                DoubleSlot = true
            };
            Timeslot timeslot11 = new Timeslot {
                Id = 11,
                StartTime = new System.TimeSpan(16, 30, 0),
                EndTime = new System.TimeSpan(17, 15, 0),
                DoubleSlot = false,
            };
            Timeslot timeslot12 = new Timeslot {
                Id = 12,
                StartTime = new System.TimeSpan(19, 00, 0),
                EndTime = new System.TimeSpan(19, 45, 0),
                DoubleSlot = false
            };

            TimeslotLink link1 = new TimeslotLink {
                Id = 1,
                BaseId = timeslot1.Id,
                LinkId = timeslot3.Id,
            };
            TimeslotLink link2 = new TimeslotLink {
                Id = 2,
                BaseId = timeslot2.Id,
                LinkId = timeslot3.Id,
            };
            TimeslotLink link3 = new TimeslotLink {
                Id = 3,
                BaseId = timeslot3.Id,
                LinkId = timeslot1.Id,
            };
            TimeslotLink link4 = new TimeslotLink {
                Id = 4,
                BaseId = timeslot3.Id,
                LinkId = timeslot2.Id,
            };

            TimeslotLink link5 = new TimeslotLink {
                Id = 5,
                BaseId = timeslot4.Id,
                LinkId = timeslot6.Id,
            };
            TimeslotLink link6 = new TimeslotLink {
                Id = 6,
                BaseId = timeslot5.Id,
                LinkId = timeslot6.Id,
            };
            TimeslotLink link7 = new TimeslotLink {
                Id = 7,
                BaseId = timeslot6.Id,
                LinkId = timeslot4.Id,
            };
            TimeslotLink link8 = new TimeslotLink {
                Id = 8,
                BaseId = timeslot6.Id,
                LinkId = timeslot5.Id,
            };

            TimeslotLink link9 = new TimeslotLink {
                Id = 9,
                BaseId = timeslot8.Id,
                LinkId = timeslot10.Id,
            };
            TimeslotLink link10 = new TimeslotLink {
                Id = 10,
                BaseId = timeslot9.Id,
                LinkId = timeslot10.Id,
            };
            TimeslotLink link11 = new TimeslotLink {
                Id = 11,
                BaseId = timeslot10.Id,
                LinkId = timeslot8.Id,
            };
            TimeslotLink link12 = new TimeslotLink {
                Id = 12,
                BaseId = timeslot10.Id,
                LinkId = timeslot9.Id,
            };


            modelBuilder.Entity<Timeslot>().HasData(
               timeslot1,
               timeslot2,
               timeslot3,
               timeslot4,
               timeslot5,
               timeslot6,
               timeslot7,
               timeslot8,
               timeslot9,
               timeslot10,
               timeslot11,
               timeslot12
           );
            modelBuilder.Entity<TimeslotLink>().HasData(
                  link1,
                  link2,
                  link3,
                  link4,
                  link5,
                  link6,
                  link7,
                  link8,
                  link9,
                  link10,
                  link11,
                  link12
            );
        }
    }
}