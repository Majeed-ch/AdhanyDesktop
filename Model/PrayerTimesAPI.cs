using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdhanyDesktop.Model
{
    internal class PrayerTimesAPI
    {
    }

    public class Data
    {
        public Timings Timings { get; set; }
        public Date Date { get; set; }
    }

    public class Timings
    {
        public string Fajr { get; set; }
        public string Sunrise { get; set; }
        public string Dhuhr { get; set; }
        public string Asr { get; set; }
        public string Sunset { get; set; }
        public string Maghrib { get; set; }
        public string Isha { get; set; }
    }

    public class Date
    {
        public string Readable { get; set; }
        public Hijri Hijri { get; set; }
        public Gregorian Gregorian { get; set; }
    }

    public class Hijri
    {
        public string Date { get; set; }
        public string Format { get; set; }
        public string Day { get; set; }
        public Weekday Weekday { get; set; }
        public Month Month { get; set; }
        public string Year { get; set; }
    }

    public class Weekday
    {
        public string En { get; set; }
        public string Ar { get; set; }
    }

    public class Month
    {
        public int Number { get; set; }
        public string En { get; set; }
        public string Ar { get; set; }
    }

    public class Gregorian
    {
        public string Date { get; set; }
        public string Format { get; set; }
        public string Day { get; set; }
        public GregorianWeekday Weekday { get; set; }
        public GregorianMonth Month { get; set; }
        public string GregorianYear { get; set; }
    }

    public class GregorianWeekday
    {
        public string En { get; set; }
    }

    public class GregorianMonth
    {
        public int Number { get; set; }
        public string En { get; set; }
    }

}
