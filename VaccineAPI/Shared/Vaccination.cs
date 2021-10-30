using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineAPI.Shared
{
    public class Vaccination
    {
        public int VaccinationID { get; set; }
        public Country Country { get; set; }
        public Vaccine Vaccine { get; set; }
        public int FirstDose { get; set; }
        public int SecondDose { get; set; }
        public double Percentage { get; set; }
    }
}
