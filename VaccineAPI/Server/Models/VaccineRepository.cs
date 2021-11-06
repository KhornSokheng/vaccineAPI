using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;

namespace VaccineAPI.Server.Models
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly AppDbContext appDbContext;
        public VaccineRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Task<Vaccine> AddVaccine(Vaccine vaccine)
        {
            throw new NotImplementedException();
        }

        public Task<Vaccine> GetVaccine(int vaccineID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vaccine>> GetVaccines()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vaccine>> Search(string vaccineName)
        {
            throw new NotImplementedException();
        }

        public Task<Vaccine> UpdateVaccine(Vaccine vaccine)
        {
            throw new NotImplementedException();
        }
    }
}
