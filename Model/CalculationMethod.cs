using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdhanyDesktop.Model
{
    public class CalculationMethod
    {
        public static Dictionary<int, string> methodDictionary = new Dictionary<int, string>
        {
            {100, "Auto calculation based on City" },
            {0, "Shia Ithna-Ansari"},
            {1, "University of Islamic Sciences, Karachi"},
            {2, "Islamic Society of North America"},
            {3, "Muslim World League"},
            {4, "Umm Al-Qura University, Makkah"},
            {5, "Egyptian General Authority of Survey"},
            {7, "Institute of Geophysics, University of Tehran"},
            {8, "Gulf Region"},
            {9, "Kuwait"},
            {10, "Qatar"},
            {11, "Majlis Ugama Islam Singapura, Singapore"},
            {12, "Union Organization islamic de France"},
            {13, "Diyanet İşleri Başkanlığı, Turkey"},
            {14, "Spiritual Administration of Muslims of Russia"}
        };


        public int id { get; set; }
        public string name { get; set; }
    }


}
