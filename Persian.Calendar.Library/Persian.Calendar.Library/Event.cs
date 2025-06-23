using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persian.Calendar.Library
{
    public class Event
    {
        public static DateTime UpdateDateTime => new DateTime(year: 2025, month: 06, day: 23, hour: 13, minute: 10, second: 0);

        public CalendarType CalendarType { get; set; }

        public int? Year { get; set; }

        public byte? Month { get; set; }

        public byte? Day { get; set; }

        public string Description { get; set; }

        public bool IsHoliday { get; set; }

        public static List<Event> GetEvents()
        {
            return GetPersianEvents()
                .Union(GetHijriEvents())
                .Union(GetGregorianEvents())
                .ToList();
        }

        private static List<Event> GetPersianEvents()
        {
            var events = new List<Event>() { };
            #region PersianEvents
            #endregion
            events.ForEach(x => x.CalendarType = CalendarType.PersianCalendar);
            return events;
        }

        private static List<Event> GetHijriEvents()
        {
            var events = new List<Event>() { };
            #region HijriEvents
            #endregion
            events.ForEach(x => x.CalendarType = CalendarType.HijriCalendar);
            return events;
        }

        private static List<Event> GetGregorianEvents()
        {
            var events = new List<Event>() { };
            #region GregorianEvents
            #endregion
            events.ForEach(x => x.CalendarType = CalendarType.GregorianCalendar);
            return events;
        }
    }
}
