using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineAPI.Shared
{
    public class Vaccine
    {
        public int VaccineID { get; set; }
        public string VaccineName { get; set; }
        public string OriginCountry { get; set; }
        public Country Country { get; set; }
        public string Description { get; set; }
    }
}
