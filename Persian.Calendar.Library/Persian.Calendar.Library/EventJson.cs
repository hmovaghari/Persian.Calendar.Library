using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persian.Calendar.Library
{
    public class EventJson
    {
        public int? Year { get; set; }

        public byte? Month { get; set; }

        public byte? Day { get; set; }

        public string Description { get; set; }

        public bool IsHoliday { get; set; }
    }
}
