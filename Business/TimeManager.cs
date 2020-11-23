using System;

namespace Acupunctuur.Business {
    public class TimeManager {
        public static readonly int DAY_LIMIT = 28;
        private readonly TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");

        public DateTime Today() {
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, targetTimeZone).Date;
        }

        public DateTime LastDay() {
            return Today().AddDays(DAY_LIMIT);
        }

        public DateTime Now() {
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, targetTimeZone);
        }

        public DateTime PreviousDay(DateTime input) {
            switch(input.DayOfWeek) {
                case DayOfWeek.Monday:
                    return input.AddDays(-3);
                case DayOfWeek.Sunday:
                    return input.AddDays(-2);
                default:
                    return input.AddDays(-1);
            }
        }

        public DateTime NextDay(DateTime input) {
            switch (input.DayOfWeek) {
                case DayOfWeek.Friday:
                    return input.AddDays(3);
                case DayOfWeek.Saturday:
                    return input.AddDays(2);
                default:
                    return input.AddDays(1);
            }
        }
    }
}
