using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdhanyDesktop.Model
{

    public class CountryCityModel
    {
        public Country[] countries { get; set; }
    }

    public class Country
    {
        public string name { get; set; }
        public string iso { get; set; }
        public City[] cities { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }


}

