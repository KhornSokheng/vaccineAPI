using Microsoft.EntityFrameworkCore;
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
        private readonly ICountryRepository countryRepository;
        private readonly IVaccineRepository vaccineRepository;
        public VaccinationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Vaccination> AddVaccination(Vaccination vaccination)
        {
            var result = await appDbContext.Vaccinations.AddAsync(vaccination);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteVaccination(int vaccinationID)
        {
            var result = await appDbContext.Vaccinations
                .FirstOrDefaultAsync(e => e.VaccinationID == vaccinationID);
            if (result != null)
            {
                appDbContext.Vaccinations.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Vaccination> GetVaccination(int vaccinationID)
        {
            return await appDbContext.Vaccinations
            .FirstOrDefaultAsync(d => d.VaccinationID == vaccinationID);
        }

        public async Task<IEnumerable<Vaccination>> GetVaccinations()
        {
            return await appDbContext.Vaccinations.ToListAsync();
        }

        public async Task<IEnumerable<Vaccination>> Search(int countryID, int vaccineID)
        {
            IQueryable<Vaccination> query = appDbContext.Vaccinations;


            if (countryID != 0)
            {
                
                query = query.Where(e => e.CountryID == countryID);
            }

            if (vaccineID != 0)
            {
                
                query = query.Where(e => e.VaccineID == vaccineID);
            }

            return await query.ToListAsync();
        }

        public async Task<Vaccination> UpdateVaccination(Vaccination vaccination)
        {
            var result = await appDbContext.Vaccinations
                .FirstOrDefaultAsync(e => e.VaccinationID == vaccination.VaccinationID);
            if (result != null)
            {
                result.CountryID = vaccination.CountryID;
                result.VaccineID = vaccination.VaccineID;
                result.FirstDose = vaccination.FirstDose;
                result.SecondDose = vaccination.SecondDose;
                result.Percentage = vaccination.Percentage;


                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
