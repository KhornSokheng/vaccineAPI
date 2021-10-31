using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineAPI.Shared
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int Population { get; set; }
        public int ContinentID { get; set; }
        public Continent Continent { get; set; }
    }
}
