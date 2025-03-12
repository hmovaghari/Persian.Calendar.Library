using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persian.Calendar.Library
{
    public static class EXMethods
    {
        public static string ToPersianNumber(this int number)
        {
            return CalendarFunctions.ToPersianNumber(number.ToString());
        }

        public static string ToPersianNumber(this long number)
        {
            return CalendarFunctions.ToPersianNumber(number.ToString());
        }

        public static string ToPersianNumber(this string number)
        {
            return CalendarFunctions.ToPersianNumber(number);
        }

        public static string ToPersianOrdinalNumber(this int number)
        {
            return CalendarFunctions.ToPersianOrdinalNumber(number);
        }
    }
}
