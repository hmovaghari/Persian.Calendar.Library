using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persian.Calendar.Library
{
    public class Calendar
    {
        public DateTime SelectedDateTime { get; set; }

        public Calendar(DateTime dateTime, int hijriAdjustment = 0)
        {
            SelectedDateTime = dateTime;
            HijriAdjustment = hijriAdjustment;
        }

        public Calendar(int hijriAdjustment = 0) : this(DateTime.Now, hijriAdjustment)
        {
            
        }

        public static bool IsValidRegion
        {
            get => CalendarFunctions.IsValidRegion();
        }

        public static int? GetHijriAdjustmentOnline(DateTime dateTime)
        {
            return CalendarFunctions.GetHijriAdjustmentOnline(dateTime);
        }

        public int HijriAdjustment { get; set; }

        public int GregorianYear
        {
            get => SelectedDateTime.Year;
        }

        public int PersianYear
        {
            get => CalendarFunctions.GetPersianYear(SelectedDateTime);
        }

        public int HijriYear
        {
            get => CalendarFunctions.GetHijriYear(SelectedDateTime, HijriAdjustment);
        }

        public int GregorianMonth
        {
            get => SelectedDateTime.Month;
        }

        public int PersianMonth
        {
            get => CalendarFunctions.GetPersianMonth(SelectedDateTime);
        }

        public int HijriMonth
        {
            get => CalendarFunctions.GetHijriMount(SelectedDateTime, HijriAdjustment);
        }

        public string GregorianMonthTiltePersian
        {
            get => CalendarFunctions.GetGregorianMonthTiltePersian(SelectedDateTime);
        }


        public string PersianMonthTitle
        {
            get => CalendarFunctions.GetPersianMonthTitle(SelectedDateTime);
        }

        public string HijriMonthTitle
        {
            get => CalendarFunctions.GetHijriMonthTitle(SelectedDateTime, HijriAdjustment);
        }


        public int GregorianDay
        {
            get => SelectedDateTime.Day;
        }

        public int PersianDay
        {
            get => CalendarFunctions.GetPersianDay(SelectedDateTime);
        }

        public int HijriDay
        {
            get => CalendarFunctions.GetHijriDay(SelectedDateTime, HijriAdjustment);
        }

        public int GregorianDayOfYear
        {
            get => SelectedDateTime.DayOfYear;
        }

        public int PersianDayOfYear
        {
            get => CalendarFunctions.GetPersianDayOfYear(SelectedDateTime);
        }

        public int HijriDayOfYear
        {
            get => CalendarFunctions.GetHijriDayOfYear(SelectedDateTime, HijriAdjustment);
        }

        public string PersianDayOfWeek
        {
            get => CalendarFunctions.GetPersianDayOfWeek(SelectedDateTime.DayOfWeek);
        }

        public string PersianEvents
        {
            get => "";
        }

        public static string GetCultureInfo(CalendarType calendarType)
        {
            return calendarType == CalendarType.PersianCalendar ? "fa-ir"
                : calendarType == CalendarType.HijriCalendar ? "ar-SA"
                : calendarType == CalendarType.GregorianCalendar ? "en-US"
                : null;
        }

    }
}
