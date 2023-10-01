using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdhanyDesktop.Model
{
    public class PrayerTimesAPI
    {
        public Data Data { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string Country { get; set; }
        public string City { get; set; }
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
        public string readable { get; set; }
        public Hijri hijri { get; set; }
        public Gregorian gregorian { get; set; }
    }

    public class Hijri
    {
        public string date { get; set; }
        public string format { get; set; }
        public string day { get; set; }
        public Weekday weekday { get; set; }
        public Month month { get; set; }
        public string year { get; set; }
    }

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

    public class Gregorian
    {
        public string date { get; set; }
        public string format { get; set; }
        public string day { get; set; }
        public GregorianWeekday weekday { get; set; }
        public GregorianMonth month { get; set; }
        public string gregorianYear { get; set; }
    }

    public class GregorianWeekday
    {
        public string en { get; set; }
    }

    public class GregorianMonth
    {
        public int number { get; set; }
        public string en { get; set; }
    }

}
