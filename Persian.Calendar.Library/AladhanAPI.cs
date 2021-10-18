using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persian.Calendar.Library
{
    //Generate Class by https://json2csharp.com

    public class Weekday
    {
        public string en { get; set; }
        public string ar { get; set; }
    }

    public class Month
    {
        public int number { get; set; }
        public string en { get; set; }
        public string ar { get; set; }
    }

    public class Designation
    {
        public string abbreviated { get; set; }
        public string expanded { get; set; }
    }

    public class Gregorian
    {
        public string date { get; set; }
        public string format { get; set; }
        public string day { get; set; }
        public Weekday weekday { get; set; }
        public Month month { get; set; }
        public string year { get; set; }
        public Designation designation { get; set; }
    }

    public class Hijri
    {
        public string date { get; set; }
        public string format { get; set; }
        public string day { get; set; }
        public Weekday weekday { get; set; }
        public Month month { get; set; }
        public string year { get; set; }
        public Designation designation { get; set; }
        public List<object> holidays { get; set; }
    }

    public class Data
    {
        public Gregorian gregorian { get; set; }
        public Hijri hijri { get; set; }
    }

    public class AladhanAPI
    {
        public int code { get; set; }
        public string status { get; set; }
        public Data data { get; set; }
    }
}
