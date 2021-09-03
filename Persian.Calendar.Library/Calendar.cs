using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persian.Calendar.Library
{
    public class Calendar
    {
        public DateTime DateTime { get; set; }

        public Calendar(DateTime dateTime, int hijriAdjustment = 0)
        {
            DateTime = dateTime;
            HijriAdjustment = hijriAdjustment;
        }

        public Calendar(int hijriAdjustment = 0)
        {
            DateTime = DateTime.Now;
            HijriAdjustment = hijriAdjustment;
        }

        public static bool IsValidRegion
        {
            get => CalendarFunctions.IsValidRegion();
        }

        public int HijriAdjustment { get; set; }

        public int GregorianYear
        {
            get => DateTime.Year;
        }

        public int PersianYear
        {
            get => CalendarFunctions.GetPersianYear(DateTime);
        }

        public int HijriYear
        {
            get => CalendarFunctions.GetHijriYear(DateTime, HijriAdjustment);
        }

        public int GregorianMonth
        {
            get => DateTime.Month;
        }

        public int PersianMonth
        {
            get => CalendarFunctions.GetPersianMonth(DateTime);
        }

        public int HijriMonth
        {
            get => CalendarFunctions.GetHijriMount(DateTime, HijriAdjustment);
        }

        public string GregorianMonthTiltePersian
        {
            get => CalendarFunctions.GetGregorianMonthTiltePersian(DateTime);
        }


        public string PersianMonthTitle
        {
            get => CalendarFunctions.GetPersianMonthTitle(DateTime);
        }

        public string HijriMonthTitle
        {
            get => CalendarFunctions.GetHijriMonthTitle(DateTime, HijriAdjustment);
        }


        public int GregorianDay
        {
            get => DateTime.Day;
        }

        public int PersianDay
        {
            get => CalendarFunctions.GetPersianDay(DateTime);
        }

        public int HijriDay
        {
            get => CalendarFunctions.GetHijriDay(DateTime, HijriAdjustment);
        }

        public int GregorianDayOfYear
        {
            get => DateTime.DayOfYear;
        }

        public int PersianDayOfYear
        {
            get => CalendarFunctions.GetPersianDayOfYear(DateTime);
        }

        public int HijriDayOfYear
        {
            get => CalendarFunctions.GetHijriDayOfYear(DateTime, HijriAdjustment);
        }

        public string PersianDayOfWeek
        {
            get => CalendarFunctions.GetPersianDayOfWeek(DateTime.DayOfWeek);
        }

        public string PersianEvents
        {
            get => "";
        }

    }
}
