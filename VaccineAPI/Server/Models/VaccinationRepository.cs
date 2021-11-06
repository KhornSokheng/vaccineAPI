using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;

namespace VaccineAPI.Server.Models
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly AppDbContext appDbContext;
        public VaccinationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Task<Vaccination> AddVaccination(Vaccination vaccination)
        {
            throw new NotImplementedException();
        }

        public Task<Vaccination> GetVaccination(int vaccinationID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vaccination>> GetVaccinations()
        {
            throw new NotImplementedException();
        }

        public Task<Vaccination> UpdateVaccination(Vaccination vaccination)
        {
            throw new NotImplementedException();
        }
    }
}
