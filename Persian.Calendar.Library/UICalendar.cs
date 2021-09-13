using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Persian.Calendar.Library
{
    public partial class UICalendar : UserControl
    {
        private CalendarType calendarType;
        private Bitmap CalendarImage = null;

        public CalendarType CalendarType
        {
            get => calendarType;
            set
            {
                calendarType = value;
                switch (value)
                {
                    case CalendarType.PersianCalendar:
                        monthView.DefaultCalendar = monthView.PersianCalendar;
                        monthView.DefaultCulture = monthView.PersianCulture;
                        break;
                    case CalendarType.HijriCalendar:
                        monthView.DefaultCalendar = monthView.HijriCalendar;
                        monthView.DefaultCulture = monthView.ArabicCulture;
                        break;
                    case CalendarType.GregorianCalendar:
                        monthView.DefaultCalendar = monthView.InvariantCalendar;
                        monthView.DefaultCulture = monthView.InvariantCulture;
                        break;
                    default:
                        break;
                }
            }
        }

        private int? hijriAdjustment;

        public int? HijriAdjustment
        {
            get => hijriAdjustment;
            set => hijriAdjustment = value;
        }

        public DateTime? SelectedDateTime
        {
            get => monthView.SelectedDateTime;
            set
            {
                if (value != null && CalendarType == CalendarType.HijriCalendar && hijriAdjustment != null)
                {
                    monthView.SelectedDateTime = ((DateTime)value).AddDays((int)hijriAdjustment);
                }
                else
                {
                    monthView.SelectedDateTime = value;
                }
            }
        }

        public UICalendar()
        {
            InitializeComponent();
        }

        public Image GetScreenShot()
        {
            CalendarImage = new Bitmap(monthView.Width, monthView.Height);
            monthView.DrawToBitmap(CalendarImage, new Rectangle(0, 0, CalendarImage.Width, CalendarImage.Height));
            return CalendarImage;
        }
    }
}
