using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Persian.Calendar.Library
{
    internal static class CalendarFunctions
    {
        internal static PersianCalendar persianCalendar = new PersianCalendar();

        internal static HijriCalendar hijriCalendar = new HijriCalendar();

        internal static void SetHijriAdjustment(int hijriAdjustment)
        {
            hijriCalendar.HijriAdjustment = hijriAdjustment;
        }

        internal static int? GetHijriAdjustmentOnlineFromAladhan(DateTime dateTime)
        {
            var webClient = new WebClient();
            var _hijriCalendar = new HijriCalendar();
            var _dateTime = new DateTime?();
            var output = new int?();

            string urlAddress = "https://api.aladhan.com/v1/hToG?date=" +
                _hijriCalendar.GetDayOfMonth(dateTime) + "-" +
                _hijriCalendar.GetMonth(dateTime) + "-" +
                _hijriCalendar.GetYear(dateTime);

            try
            {
                var jsonRespoce = webClient.DownloadString(urlAddress);
                var aladhanH2G = JsonConvert.DeserializeObject<AladhanAPI>(jsonRespoce);
                _dateTime = new DateTime(int.Parse(aladhanH2G.data.gregorian.year),
                    aladhanH2G.data.gregorian.month.number,
                    int.Parse(aladhanH2G.data.gregorian.day));
                output = (dateTime.Date - ((DateTime)_dateTime).Date).Days;
            }
            catch
            {
                output = null;
            }
            finally
            {
                webClient.Dispose();
            }

            return output;
        }

        internal static async Task<int?> GetHijriAdjustmentOnlineFromTimeIR(DateTime dateTime)
        {
            try
            {
                string url = "https://time.ir";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();
                        //<span id="ctl00_cphTop_Sampa_Web_View_TimeUI_ShowDate00cphTop_3734_lblHijriNumeral" class="show numeral">۱۴۴۶/۰۹/۱۳</span>
                        var pattern = @"<span id=""ctl00_cphTop_Sampa_Web_View_TimeUI_ShowDate\d+cphTop_\d+_lblHijriNumeral"" class=""show numeral"">([\d/]+)</span>";
                        var match = Regex.Match(htmlContent, pattern);
                        if (match.Success)
                        {
                            var hijriStringDate = ToEnglishNumber(match.Groups[1].Value);
                            CultureInfo arSA = new CultureInfo("ar-SA");
                            arSA.DateTimeFormat.Calendar = new HijriCalendar();
                            var gregorianDate = DateTime.ParseExact(hijriStringDate, "yyyy/MM/dd", arSA);
                            return (gregorianDate.Date - dateTime.Date ).Days;
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static bool IsValidRegion()
        {
            var enCulter = CultureInfo.GetCultureInfo("en-US");
            var now = DateTime.Now.Date;
            var gregorianDate = now.ToString(enCulter);
            var regionDate = now.ToString();
            return gregorianDate == regionDate;
        }

        internal static int GetPersianYear(DateTime dateTime)
        {
            return persianCalendar.GetYear(dateTime);
        }

        internal static int GetHijriYear(DateTime dateTime, int hijriAdjustment)
        {
            SetHijriAdjustment(hijriAdjustment);
            return hijriCalendar.GetYear(dateTime);
        }

        internal static int GetPersianMonth(DateTime dateTime)
        {
            return persianCalendar.GetMonth(dateTime);
        }

        internal static int GetHijriMount(DateTime dateTime, int hijriAdjustment)
        {
            SetHijriAdjustment(hijriAdjustment);
            return hijriCalendar.GetMonth(dateTime);
        }

        internal static int GetPersianDay(DateTime dateTime)
        {
            return persianCalendar.GetDayOfMonth(dateTime);
        }

        internal static int GetHijriDay(DateTime dateTime, int hijriAdjustment)
        {
            SetHijriAdjustment(hijriAdjustment);
            return hijriCalendar.GetDayOfMonth(dateTime);
        }

        internal static int GetPersianDayOfYear(DateTime dateTime)
        {
            return persianCalendar.GetDayOfYear(dateTime);
        }

        internal static int GetHijriDayOfYear(DateTime dateTime, int hijriAdjustment)
        {
            SetHijriAdjustment(hijriAdjustment);
            return hijriCalendar.GetDayOfYear(dateTime);
        }

        internal static string GetPersianDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Tuesday:
                    return "سه‌شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                case DayOfWeek.Thursday:
                    return "پنج‌شنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                case DayOfWeek.Saturday:
                    return "شنبه";
                default:
                    return string.Empty;
            }
        }

        internal static string GetGregorianMonthTiltePersian(DateTime dateTime)
        {
            switch (dateTime.Month)
            {
                case 1:
                    return "ژانویه";
                case 2:
                    return "فوریه";
                case 3:
                    return "مارس";
                case 4:
                    return "آوریل";
                case 5:
                    return "می";
                case 6:
                    return "ژوئن";
                case 7:
                    return "ژولای";
                case 8:
                    return "آگست";
                case 9:
                    return "سپتامبر";
                case 10:
                    return "اکتبر";
                case 11:
                    return "نوامبر";
                case 12:
                    return "دسامبر";
                default:
                    return string.Empty;
            }
        }

        internal static string GetPersianMonthTitle(DateTime dateTime)
        {
            switch (GetPersianMonth(dateTime))
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return string.Empty;
            }
        }

        internal static string GetHijriMonthTitle(DateTime dateTime, int hijriAdjustment)
        {
            switch (GetHijriMount(dateTime, hijriAdjustment))
            {
                case 1:
                    return "محرم";
                case 2:
                    return "صفر";
                case 3:
                    return "ربیع‌الاول";
                case 4:
                    return "ربیع‌الثانی";
                case 5:
                    return "جمادی‌الاول";
                case 6:
                    return "جمادی‌الثانی";
                case 7:
                    return "رجب";
                case 8:
                    return "شعبان";
                case 9:
                    return "رمضان";
                case 10:
                    return "شوال";
                case 11:
                    return "ذیقعده";
                case 12:
                    return "ذیحجه";
                default:
                    return string.Empty;
            }
        }

        internal static string ToPersianNumber(string number)
        {
            return number.Replace("0", "۰")
                    .Replace("1", "۱")
                    .Replace("2", "۲")
                    .Replace("3", "۳")
                    .Replace("4", "۴")
                    .Replace("5", "۵")
                    .Replace("6", "۶")
                    .Replace("7", "۷")
                    .Replace("8", "۸")
                    .Replace("9", "۹");
        }

        internal static string ToEnglishNumber(string number)
        {
            return number
                .Replace("۰", "0")
                .Replace("٠", "0")
                .Replace("٠", "0")
                .Replace("۱", "1")
                .Replace("١", "1")
                .Replace("۲", "2")
                .Replace("٢", "2")
                .Replace("۳", "3")
                .Replace("٣", "3")
                .Replace("۴", "4")
                .Replace("٤", "4")
                .Replace("۵", "5")
                .Replace("٥", "5")
                .Replace("۶", "6")
                .Replace("٦", "6")
                .Replace("۷", "7")
                .Replace("٧", "7")
                .Replace("۸", "8")
                .Replace("٨", "8")
                .Replace("۹", "9")
                .Replace("٩", "9");
        }

        internal static string ToPersianOrdinalNumber(int number)
        {
            var day_p2 = number % 10;
            var day_p1 = (number - day_p2) / 10;
            var message = "";
            var mode = 0;

            switch (day_p1)
            {
                case 0:
                    mode = 0;
                    break;
                case 1:
                    if (day_p2 == 0)
                        message = "دهم";
                    else
                        mode = 1;
                    break;
                case 2:
                    if (day_p2 == 0)
                        message = "بیستم";
                    else
                        mode = 2;
                    break;
                case 3:
                    message = day_p2 == 0 ? "سی ام" : "سی و یکم";
                    break;
            }

            if (mode == 2)
            {
                message = "بیست و ";
            }

            if (mode == 2 || mode == 0)
            {
                if (mode == 2 || day_p1 != 3)
                {
                    switch (day_p2)
                    {
                        case 1:
                            message += "یکم";
                            break;
                        case 2:
                            message += "دوم";
                            break;
                        case 3:
                            message += "سوم";
                            break;
                        case 4:
                            message += "چهارم";
                            break;
                        case 5:
                            message += "پنجم";
                            break;
                        case 6:
                            message += "ششم";
                            break;
                        case 7:
                            message += "هفتم";
                            break;
                        case 8:
                            message += "هشتم";
                            break;
                        case 9:
                            message += "نهم";
                            break;
                    }
                }
            }
            else
            {
                switch (day_p2)
                {
                    case 1:
                        message = "یازدهم";
                        break;
                    case 2:
                        message = "دوازدهم";
                        break;
                    case 3:
                        message = "سیزدهم";
                        break;
                    case 4:
                        message = "چهاردهم";
                        break;
                    case 5:
                        message = "پانزدهم";
                        break;
                    case 6:
                        message = "شانزدهم";
                        break;
                    case 7:
                        message = "هفدهم";
                        break;
                    case 8:
                        message = "هجدهم";
                        break;
                    case 9:
                        message = "نوزدهم";
                        break;
                }
            }
            return message;
        }
    }
}
