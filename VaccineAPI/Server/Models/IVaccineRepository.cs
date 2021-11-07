using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;

namespace VaccineAPI.Server.Models
{
    public interface IVaccineRepository
    {
        Task<IEnumerable<Vaccine>> GetVaccines();
        Task<Vaccine> GetVaccine(int vaccineID);
        Task<IEnumerable<Vaccine>> Search(string vaccineName);
        Task<Vaccine> AddVaccine(Vaccine vaccine);
        Task<Vaccine> UpdateVaccine(Vaccine vaccine);
        Task DeleteVaccine(int vaccineID);
    }
}
