using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;

namespace VaccineAPI.Server.Models
{
    public interface IVaccinationRepository
    {
        Task<IEnumerable<Vaccination>> GetVaccinations();
        Task<Vaccination> GetVaccination(int vaccinationID);

        Task<IEnumerable<Vaccination>> Search(int countryID, int vaccineID);

        Task<Vaccination> AddVaccination(Vaccination vaccination);
        Task<Vaccination> UpdateVaccination(Vaccination vaccination);
        Task DeleteVaccination(int vaccinationID);
    }
}
